using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyLoaiNhaDatController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyLoaiNhaDatController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyLoaiNhaDat
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

            var viewModel = new QuanLyLoaiNhaDatViewModel
            {
                LoaiNhaDats = _context.LoaiNhaDats.ToList()
            };

            return View(viewModel);
        }

        public ViewResult New()
        {
            var viewModel = new LoaiNhaDatViewModel();
            return View("LoaiNhaDatForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var loaiNhaDat = _context.LoaiNhaDats.SingleOrDefault(X => X.Id == id);
            if (loaiNhaDat == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiNhaDatViewModel(loaiNhaDat);
            return View("LoaiNhaDatForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var loaiNhaDat = _context.LoaiNhaDats.SingleOrDefault(X => X.Id == id);
            if (loaiNhaDat == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiNhaDatViewModel(loaiNhaDat);
            return View(loaiNhaDat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LoaiNhaDat loaiNhaDat)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoaiNhaDatViewModel();
                return View("LoaiNhaDatForm", viewModel);
            }

            if (loaiNhaDat.Id == 0)
            {
                _context.LoaiNhaDats.Add(loaiNhaDat);
                TempData["success"] = "Thêm mới thành công";
            }
            else
            {
                var loaiNhaDatInDb = _context.LoaiNhaDats.Single(x => x.Id == loaiNhaDat.Id);
                loaiNhaDatInDb.TenLoai = loaiNhaDat.TenLoai;
                loaiNhaDatInDb.IsRent = loaiNhaDat.IsRent;
                TempData["success"] = "Cập nhật thành công";
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLyLoaiNhaDat");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            var loaiNhaDat = _context.LoaiNhaDats.Single(x => x.Id == id);

            try
            {
                _context.LoaiNhaDats.Remove(loaiNhaDat);
                _context.SaveChanges();
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa loại nhà đất đã có dữ liệu nhà đất";
                ExceptionLogger.SendErrorToText(ex);
            }

            return RedirectToAction("Index", "QuanLyLoaiNhaDat");
        }

    }
}