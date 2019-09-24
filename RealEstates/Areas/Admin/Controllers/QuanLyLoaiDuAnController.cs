using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyLoaiDuAnController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyLoaiDuAnController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyLoaiDuAn
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }

            var viewModel = new QuanLyLoaiDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                DuAns = _context.DuAns.Include(x => x.LoaiDuAn).ToList()
            };

            return View(viewModel);
        }

        public ViewResult New()
        {
            var viewModel = new LoaiDuAnViewModel();
            return View("LoaiDuAnForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var loaiDuAn = _context.LoaiDuAns.SingleOrDefault(x => x.Id == id);
            if (loaiDuAn == null)
            {
                return HttpNotFound();
            }
            var viewModel = new LoaiDuAnViewModel(loaiDuAn);

            return View("LoaiDuAnForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var loaiDuAn = _context.LoaiDuAns.SingleOrDefault(x => x.Id == id);
            if (loaiDuAn == null)
            {
                return HttpNotFound();
            }

            return View(loaiDuAn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LoaiDuAn loaiDuAn)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoaiDuAnViewModel();
                return View("LoaiDuAnForm", viewModel);
            }

            if (loaiDuAn.Id == 0)
            {
                _context.LoaiDuAns.Add(loaiDuAn);
                TempData["success"] = "Thêm mới thành công";
            }
            else
            {
                var loaiDuAnInDb = _context.LoaiDuAns.Single(x => x.Id == loaiDuAn.Id);
                loaiDuAnInDb.TenLoai = loaiDuAn.TenLoai;
                loaiDuAnInDb.MoTa = loaiDuAn.MoTa;
                TempData["success"] = "Cập nhật thành công";
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyLoaiDuAn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            var loaiDuAn = _context.LoaiDuAns.Single(x => x.Id == id);
            try
            {
                _context.LoaiDuAns.Remove(loaiDuAn);
                _context.SaveChanges();
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa do loại dự án đã có dữ liệu dự án";
                ExceptionLogger.SendErrorToText(ex);
            }

            return RedirectToAction("Index", "QuanLyLoaiDuAn");
        }
    }
}