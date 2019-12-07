using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RealEstates.Helper;
using Microsoft.AspNet.Identity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.SalesMan)]
    public class QuanLyBaoCaoCongViecController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyBaoCaoCongViecController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyBaoCaoCongViec
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

            var userId = User.Identity.GetUserId();
            var salesMan = _context.NhanViens.Single(y => y.Account.Id == userId);
            var phanCongsInDb = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhaDat.DuAn).Include(x => x.NhanVienSales)
                .Where(x => x.NhanVienSales.Id == salesMan.Id).ToList();
            var phanCongViewModels = new List<PhanCongSalesViewModel>();
            var duAns = new List<DuAn>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSalesViewModel(phanCongInDb);
                phanCong.NhaDat = phanCongInDb.NhaDat;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
                duAns.Add(phanCongInDb.NhaDat.DuAn);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new QuanLyBaoCaoCongViecViewModel
            {
                PhanCongSales = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales,
                DuAns = duAns
            };
            return View(viewModel);
        }

        public ActionResult Search(int? trangThai, int? duAnId)
        {
            var userId = User.Identity.GetUserId();
            var salesMan = _context.NhanViens.Single(y => y.Account.Id == userId);
            var phanCongsInDb = _context.PhanCongSales.Include(x => x.NhaDat.DuAn).Include(x => x.NhanVienSales)
                .Where(x => x.NhanVienSales.Id == salesMan.Id).ToList();
            var phanCongViewModels = new List<PhanCongSalesViewModel>();
            var duAns = new List<DuAn>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSalesViewModel(phanCongInDb);
                phanCong.NhaDat = phanCongInDb.NhaDat;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
                duAns.Add(phanCongInDb.NhaDat.DuAn);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new QuanLyBaoCaoCongViecViewModel
            {
                PhanCongSales = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales,
                DuAns = duAns
            };

            if (trangThai.HasValue)
            {
                viewModel.TrangThai = trangThai.Value;
                viewModel.PhanCongSales = viewModel.PhanCongSales.Where(x => x.TrangThai == trangThai);
            }

            if (duAnId.HasValue)
            {
                viewModel.DuAnId = duAnId.Value;
                viewModel.PhanCongSales = viewModel.PhanCongSales.Where(x => x.NhaDat.DuAn.Id == duAnId);
            }

            return View("Index", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var phanCongSales = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongSales == null)
            {
                return HttpNotFound();
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new BaoCaoCongViecViewModel
            {
                PhanCongSales = phanCongSales,
                TrangThaiCongViec = SelectOptions.getTrangThaiPhanCongSales
            };
            return View("BaoCaoCongViecForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var phanCongInDb = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongInDb == null)
            {
                return HttpNotFound();
            }
            return View(phanCongInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PhanCongSales phanCongSales)
        {
            if (!ModelState.IsValid)
            {
                var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
                var viewModel = new BaoCaoCongViecViewModel
                {
                    PhanCongSales = phanCongSales,
                    TrangThaiCongViec = SelectOptions.getTrangThaiPhanCongSales
                };
                return View("BaoCaoCongViecForm", viewModel);
            }

            var phanCongInDb = _context.PhanCongSales.Single(x => x.Id == phanCongSales.Id);
            phanCongInDb.TrangThai = phanCongSales.TrangThai;
            TempData["success"] = "Cập nhật thành công";

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyBaoCaoCongViec");
        }

    }
}