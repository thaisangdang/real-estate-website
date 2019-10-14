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
            var phanCongsInDb = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales)
                .Where(x => x.NhanVienSales.Id == salesMan.Id).ToList();
            var phanCongViewModels = new List<PhanCongSanPhamViewModel>();
            var duAns = new List<DuAn>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSanPhamViewModel(phanCongInDb);
                phanCong.DuAn = phanCongInDb.DuAn;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
                duAns.Add(phanCongInDb.DuAn);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new QuanLyBaoCaoCongViecViewModel
            {
                PhanCongSanPhams = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham,
                DuAns = duAns
            };
            return View(viewModel);
        }

        public ActionResult Search(int? trangThai, int? duAnId)
        {
            var userId = User.Identity.GetUserId();
            var salesMan = _context.NhanViens.Single(y => y.Account.Id == userId);
            var phanCongsInDb = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales)
                .Where(x => x.NhanVienSales.Id == salesMan.Id).ToList();
            var phanCongViewModels = new List<PhanCongSanPhamViewModel>();
            var duAns = new List<DuAn>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSanPhamViewModel(phanCongInDb);
                phanCong.DuAn = phanCongInDb.DuAn;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
                duAns.Add(phanCongInDb.DuAn);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new QuanLyBaoCaoCongViecViewModel
            {
                PhanCongSanPhams = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham,
                DuAns = duAns
            };

            if (trangThai.HasValue)
            {
                viewModel.TrangThai = trangThai.Value;
                viewModel.PhanCongSanPhams = viewModel.PhanCongSanPhams.Where(x => x.TrangThai == trangThai);
            }

            if (duAnId.HasValue)
            {
                viewModel.DuAnId = duAnId.Value;
                viewModel.PhanCongSanPhams = viewModel.PhanCongSanPhams.Where(x => x.DuAn.Id == duAnId);
            }

            return View("Index", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var phanCongSanPham = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongSanPham == null)
            {
                return HttpNotFound();
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new BaoCaoCongViecViewModel
            {
                PhanCongSanPham = phanCongSanPham,
                TrangThaiCongViec = SelectOptions.getTrangThaiPhanCongSanPham
            };
            return View("BaoCaoCongViecForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var phanCongInDb = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongInDb == null)
            {
                return HttpNotFound();
            }
            return View(phanCongInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PhanCongSanPham phanCongSanPham)
        {
            if (!ModelState.IsValid)
            {
                var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
                var viewModel = new BaoCaoCongViecViewModel
                {
                    PhanCongSanPham = phanCongSanPham,
                    TrangThaiCongViec = SelectOptions.getTrangThaiPhanCongSanPham
                };
                return View("BaoCaoCongViecForm", viewModel);
            }

            var phanCongInDb = _context.PhanCongSanPhams.Single(x => x.Id == phanCongSanPham.Id);
            phanCongInDb.TrangThai = phanCongSanPham.TrangThai;
            TempData["success"] = "Cập nhật thành công";

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyBaoCaoCongViec");
        }

    }
}