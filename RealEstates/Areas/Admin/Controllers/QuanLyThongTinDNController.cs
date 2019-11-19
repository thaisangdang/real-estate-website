using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyThongTinDNController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/QuanLyThongTinDN
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }
            if (TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"].ToString();
                TempData.Remove("error");
            }

            var viewModel = new QuanLyThongTinDNViewModel {
                DoanhNghiepBDSs = _context.DoanhNghiepBDSs.ToList()
            };

            return View(viewModel);
        }

        public ViewResult New()
        {
            return View("ThongTinDNForm");
        }

        public ActionResult Edit(int id)
        {
            var doanhNghiepBDS = _context.DoanhNghiepBDSs.SingleOrDefault(x => x.Id == id);
            if (doanhNghiepBDS == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ThongTinDNViewModel(doanhNghiepBDS);
            return View("ThongTinDNForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var doanhNghiepBDS = _context.DoanhNghiepBDSs.SingleOrDefault(x => x.Id == id);
            if (doanhNghiepBDS == null)
            {
                return HttpNotFound();
            }
            return View(doanhNghiepBDS);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DoanhNghiepBDS doanhNghiepBDS)
        {
            if (!ModelState.IsValid)
            {
                return View("ThongTinDNForm");
            }
            if (doanhNghiepBDS.ImageFile != null)
            {
                //Get Upload path from Web.Config file AppSettings.  
                string uploadPath = ConfigurationManager.AppSettings["AnhDaiDienDuAn"].ToString();
                doanhNghiepBDS.AnhDaiDien = saveFile(doanhNghiepBDS.ImageFile, uploadPath);
            }
            doanhNghiepBDS.GioiThieu = HttpUtility.HtmlDecode(doanhNghiepBDS.GioiThieu);
            if (doanhNghiepBDS.Id == 0)
            {
                TempData["success"] = "Thêm mới thành công";
                _context.DoanhNghiepBDSs.Add(doanhNghiepBDS);
            }
            else
            {
                var doanhNghiepInDb = _context.DoanhNghiepBDSs.Single(x => x.Id == doanhNghiepBDS.Id);
                doanhNghiepInDb.Ten = doanhNghiepBDS.Ten;
                doanhNghiepInDb.DiaChi = doanhNghiepBDS.DiaChi;
                doanhNghiepInDb.SoDienThoai = doanhNghiepBDS.SoDienThoai;
                doanhNghiepInDb.Email = doanhNghiepBDS.Email;
                doanhNghiepInDb.Website = doanhNghiepBDS.Website;
                doanhNghiepInDb.GioiThieu = doanhNghiepBDS.GioiThieu;
                if (!string.IsNullOrEmpty(doanhNghiepInDb.AnhDaiDien))
                {
                    deleteFile(doanhNghiepInDb.AnhDaiDien);
                    doanhNghiepInDb.AnhDaiDien = doanhNghiepBDS.AnhDaiDien;
                }
                TempData["success"] = "Cập nhật thành công";
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLyThongTinDN");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var doanhNghiep = _context.DoanhNghiepBDSs.Single(x => x.Id == id);
            var anhDaiDien = doanhNghiep.AnhDaiDien;
            try
            {
                _context.DoanhNghiepBDSs.Remove(doanhNghiep);
                _context.SaveChanges();
                deleteFile(anhDaiDien);
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa thông tin doanh nghiệp đã có thông tin dự án";
                ExceptionLogger.SendErrorToText(ex);
                throw;
            }
            return RedirectToAction("Index", "QuanLyThongTinDN");
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