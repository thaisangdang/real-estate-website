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
using RealEstates.Areas.Admin.Models;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyDuAnController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyDuAnController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyDuAn
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }

            var viewModel = new QuanLyDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(y => y.LoaiDuAn).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };

            return View(viewModel);
        }

        public ActionResult Search(int? tinhThanhPhoId, int? quanHuyenId, int? loaiDuAnId, int? trangThai)
        {
            var viewModel = new QuanLyDuAnViewModel {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };

            viewModel.DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(y => y.LoaiDuAn).ToList();

            if (tinhThanhPhoId.HasValue)
            {
                viewModel.TinhThanhPhoId = tinhThanhPhoId.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.TinhThanhPho.Id == tinhThanhPhoId);
            }

            if (quanHuyenId.HasValue)
            {
                viewModel.QuanHuyenId = quanHuyenId.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.QuanHuyen.Id == quanHuyenId);
            }

            if (loaiDuAnId.HasValue)
            {
                viewModel.LoaiDuAnId = loaiDuAnId.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.LoaiDuAn.Id == loaiDuAnId);
            }

            if (trangThai.HasValue)
            {
                viewModel.TrangThai = trangThai.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.TrangThai == trangThai);
            }

            return View("Index", viewModel);
        }

        public ViewResult New()
        {
            var viewModel = new DuAnViewModel {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
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
                QuanHuyens = _context.QuanHuyens.ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };
            return View("DuAnForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            var duAn = _context.DuAns.Include(x => x.LoaiDuAn).Include(y => y.TinhThanhPho)
                .Include(z => z.QuanHuyen).Include(u => u.NguoiDang).SingleOrDefault(x => x.Id == id);
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
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new DuAnViewModel
                {
                    LoaiDuAns = _context.LoaiDuAns.ToList(),
                    TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                    QuanHuyens = _context.QuanHuyens.ToList(),
                    TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
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
                TempData["success"] = "Thêm mới thành công";
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
                duAnInDb.SoDonViSanPham = duAn.SoDonViSanPham;
                duAnInDb.LoaiDuAnId = duAn.LoaiDuAnId;
                duAnInDb.TinhThanhPhoId = duAn.TinhThanhPhoId;
                duAnInDb.QuanHuyenId = duAn.QuanHuyenId;
                duAnInDb.TrangThai = duAn.TrangThai;
                if (!string.IsNullOrEmpty(duAn.AnhDaiDien))
                {
                    // Xóa ảnh cũ
                    deleteFile(duAnInDb.AnhDaiDien);
                    // Thay bằng ảnh mới
                    duAnInDb.AnhDaiDien = duAn.AnhDaiDien;
                }
                TempData["success"] = "Cập nhật thành công";
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
            var anhdDaiDien = duAn.AnhDaiDien;
            try
            {
                _context.DuAns.Remove(duAn);
                _context.SaveChanges();
                deleteFile(anhdDaiDien);
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa dự án đã phân công hoặc có doanh thu";
                ExceptionLogger.SendErrorToText(ex);
            }

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