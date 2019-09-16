using System;
using System.Collections.Generic;
using System.Linq;
using RealEstates.Models;
using RealEstates.ViewModels;
using System.Configuration;
using RealEstates.Helper;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; // xài eagerloading phải thêm namespace này
using Microsoft.AspNet.Identity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyDuAnController : Controller
    {
        public ApplicationDbContext _context;

        public QuanLyDuAnController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/QuanLyDuAn
        public ActionResult Index()
        {
            var duAns = new List<DuAn>();
            duAns = _context.DuAns.Include(x => x.LoaiDuAn).Include(y => y.TinhThanhPho).ToList();

            return View(duAns);
        }

        public ViewResult New()
        {
            var viewModel = new DuAnViewModel {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList()
            };

            return View("DuAnForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var duAn = _context.DuAns.SingleOrDefault(x => x.Id == id);
            if (duAn == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DuAnViewModel (duAn)
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
            };

            return View("DuAnForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var duAn = _context.DuAns.Include(x => x.LoaiDuAn).Include(y => y.TinhThanhPho).SingleOrDefault(x => x.Id == id);
            if (duAn == null)
            {
                return HttpNotFound();
            }

            return View(duAn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DuAn duAn)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new DuAnViewModel
                {
                    LoaiDuAns = _context.LoaiDuAns.ToList(),
                    TinhThanhPhos = _context.TinhThanhPhos.ToList()
                };
                return View("DuAnForm", viewModel);
            }

            if (duAn.ImageFile != null)
            {
                //Get Upload path from Web.Config file AppSettings.  
                string uploadPath = ConfigurationManager.AppSettings["AnhDaiDienDuAn"].ToString();
                duAn.AnhDaiDien = saveFile(duAn.ImageFile, uploadPath);
            }

            duAn.GioiThieuDuAn = HttpUtility.HtmlDecode(duAn.GioiThieuDuAn);
            duAn.ViTri = HttpUtility.HtmlDecode(duAn.ViTri);
            duAn.HaTang = HttpUtility.HtmlDecode(duAn.HaTang);
            duAn.ThietKe = HttpUtility.HtmlDecode(duAn.ThietKe);
            duAn.MatBang = HttpUtility.HtmlDecode(duAn.MatBang);
            duAn.Media = HttpUtility.HtmlDecode(duAn.Media);
            duAn.HoTroTaiChinh = HttpUtility.HtmlDecode(duAn.HoTroTaiChinh);

            if (duAn.Id == 0)
            {
                var userId = User.Identity.GetUserId();
                var nguoiDang = _context.NhanViens.SingleOrDefault(x => x.AccountId == userId);
                duAn.NguoiDangId = nguoiDang.Id;
                duAn.NgayDang = DateTime.Now;

                _context.DuAns.Add(duAn);
            }
            else
            {
                var duAnInDb = _context.DuAns.Single(x => x.Id == duAn.Id);
                duAnInDb.TenDuAn = duAn.TenDuAn;
                duAnInDb.DiaChi = duAn.DiaChi;
                duAnInDb.GiaTu = duAn.GiaTu;
                duAnInDb.ChuDauTu = duAn.ChuDauTu;
                duAnInDb.TongDienTich = duAn.TongDienTich;
                duAnInDb.TienDoDuAn = duAn.TienDoDuAn;
                duAnInDb.QuyMoDuAn = duAn.QuyMoDuAn;
                duAnInDb.GioiThieuDuAn = duAn.GioiThieuDuAn;
                duAnInDb.ViTri = duAn.ViTri;
                duAnInDb.HaTang = duAn.HaTang;
                duAnInDb.ThietKe = duAn.ThietKe;
                duAnInDb.MatBang = duAn.MatBang;
                duAnInDb.Media = duAn.Media;
                duAnInDb.HoTroTaiChinh = duAn.HoTroTaiChinh;
                duAnInDb.SoDonViDuAn = duAn.SoDonViDuAn;
                duAnInDb.LoaiDuAnId = duAn.LoaiDuAnId;
                duAnInDb.TinhThanhPhoId = duAn.TinhThanhPhoId;
                if (!string.IsNullOrEmpty(duAn.AnhDaiDien))
                {
                    // Xóa ảnh cũ
                    deleteFile(duAnInDb.AnhDaiDien);
                    // Thay bằng ảnh mới
                    duAnInDb.AnhDaiDien = duAn.AnhDaiDien;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyDuAn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var duAn = _context.DuAns.Single(x => x.Id == id);
            deleteFile(duAn.AnhDaiDien);

            _context.DuAns.Remove(duAn);

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyDuAn");
        }

        #region Helper
        public string saveFile(HttpPostedFileBase imageFile, string uploadPath)
        {
            string filePath = "";
            try
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imageFile.FileName);
                string fileExtension = Path.GetExtension(imageFile.FileName);
                string fileName = DateTime.Now.ToString("ddMMyyy") + "-" + fileNameWithoutExtension.Trim() + fileExtension;
                //Its Create complete path to store in server.  
                filePath = uploadPath + fileName;
                //To copy and save file into server.  
                imageFile.SaveAs(Server.MapPath(filePath));
            }
            catch (Exception ex)
            {
                ExceptionLogger.SendErrorToText(ex);
            }

            return filePath;
        }

        public void deleteFile(string filePath)
        {
            try
            {
                if (System.IO.File.Exists(Server.MapPath(filePath)))
                {
                    System.IO.File.Delete(Server.MapPath(filePath));
                }
            }
            catch (IOException ex)
            {
                ExceptionLogger.SendErrorToText(ex);
            }
        }
        #endregion

    }
}