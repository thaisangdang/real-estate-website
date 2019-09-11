using RealEstates.Areas.Admin.Models;
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
    public class QuanLyLoaiDuAnController : Controller
    {
        public ApplicationDbContext _context;

        public QuanLyLoaiDuAnController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/QuanLyLoaiDuAn
        public ActionResult Index()
        {
            var loaiDuAns = new List<LoaiDuAn>();
            loaiDuAns = _context.LoaiDuAns.ToList();

            return View(loaiDuAns);
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
            }
            else
            {
                var loaiDuAnInDb = _context.LoaiDuAns.Single(x => x.Id == loaiDuAn.Id);
                loaiDuAnInDb.TenLoai = loaiDuAn.TenLoai;
                loaiDuAnInDb.MoTa = loaiDuAn.MoTa;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyLoaiDuAn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var loaiDuAn = _context.LoaiDuAns.Single(x => x.Id == id);
            _context.LoaiDuAns.Remove(loaiDuAn);

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyLoaiDuAn");

        }
    }
}