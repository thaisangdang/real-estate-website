using Microsoft.AspNet.Identity;
using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, SalesMan, Staff")]
    public class QuanLyPhiHoaHongController : Controller 
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhiHoaHongController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhiHoaHong
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

            var duAns = new List<DuAn>();
            var nhanVienSales = new List<NhanVien>();
            var phiHoaHongs = new List<PhiHoaHong>();

            if (User.IsInRole(RoleName.SalesMan))
            {
                var salesManAccountId = User.Identity.GetUserId();
                var salesMan = _context.NhanViens.SingleOrDefault(x => x.Account.Id == salesManAccountId);
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSanPham).Include(x => x.PhanCongSanPham.NhanVienSales).Include(X => X.PhanCongSanPham.DuAn)
                    .Where(x => x.PhanCongSanPham.NhanVienSales.Id == salesMan.Id).ToList();
                foreach (var item in phiHoaHongs)
                {
                    duAns.Add(item.PhanCongSanPham.DuAn);
                }
            }
            else
            {
                var salesRole = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
                nhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == salesRole.Id).ToList();
                duAns = _context.DuAns.ToList();
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSanPham).Include(x => x.PhanCongSanPham.NhanVienSales).Include(X => X.PhanCongSanPham.DuAn).ToList();
            }

            var viewModel = new QuanLyPhiHoaHongViewModel
            {
                PhiHoaHongs = phiHoaHongs,
                DuAns = duAns,
                NhanVienSales = nhanVienSales
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New(int id)
        {
            var phanCongSanPham = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongSanPham == null)
                return HttpNotFound();

            var userId = User.Identity.GetUserId();
            var phiHoaHong = new PhiHoaHong();
            phiHoaHong.PhanCongSanPhamId = phanCongSanPham.Id;
            phiHoaHong.NguoiTaoId = _context.NhanViens.SingleOrDefault(x => x.Account.Id == userId).Id;
            var viewModel = new PhiHoaHongViewModel(phiHoaHong)
            {
                NhanVienSales = phanCongSanPham.NhanVienSales.HoTen,
                TenDuAn = phanCongSanPham.DuAn.TenDuAn,
                SanPham = phanCongSanPham.SanPham,
                IsRent = phanCongSanPham.IsRent,
                GiaThueThangDau = phanCongSanPham.GiaThueThangDau,
                GiaBanSanPham = phanCongSanPham.GiaBanSanPham,
                PhanTramHoaHong = phanCongSanPham.PhanTramHoaHong
            };
                        
            if (phanCongSanPham.IsRent)
                viewModel.TongChi = phanCongSanPham.GiaThueThangDau * (decimal)(phanCongSanPham.PhanTramHoaHong / 100);
            else
                viewModel.TongChi = phanCongSanPham.GiaBanSanPham * (decimal)(phanCongSanPham.PhanTramHoaHong / 100);

            return View("PhiHoaHongForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var phiHoaHong = _context.PhiHoaHongs.Include(x => x.PhanCongSanPham).Include(x => x.PhanCongSanPham.NhanVienSales).Include(X => X.PhanCongSanPham.DuAn).SingleOrDefault(x => x.Id == id);
            if (phiHoaHong == null)
                return HttpNotFound();
            return View(phiHoaHong);
        }

        public ActionResult Search(int? duAnId, int? nhanVienSalesId)
        {
            var duAns = new List<DuAn>();
            var nhanVienSales = new List<NhanVien>();
            var phiHoaHongs = new List<PhiHoaHong>();

            if (User.IsInRole(RoleName.SalesMan))
            {
                var salesManAccountId = User.Identity.GetUserId();
                var salesMan = _context.NhanViens.SingleOrDefault(x => x.Account.Id == salesManAccountId);
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSanPham).Include(x => x.PhanCongSanPham.NhanVienSales).Include(X => X.PhanCongSanPham.DuAn)
                    .Where(x => x.PhanCongSanPham.NhanVienSales.Id == salesMan.Id).ToList();
                foreach (var item in phiHoaHongs)
                {
                    duAns.Add(item.PhanCongSanPham.DuAn);
                }
            }
            else
            {
                var salesRole = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
                nhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == salesRole.Id).ToList();
                duAns = _context.DuAns.ToList();
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSanPham).Include(x => x.PhanCongSanPham.NhanVienSales).Include(X => X.PhanCongSanPham.DuAn).ToList();
            }

            if (duAnId.HasValue)
            {
                duAns = duAns.Where(x => x.Id == duAnId.Value).ToList();
            }

            if (nhanVienSalesId.HasValue)
            {
                nhanVienSales = nhanVienSales.Where(x => x.Id == nhanVienSalesId.Value).ToList();
            }

            var viewModel = new QuanLyPhiHoaHongViewModel
            {
                PhiHoaHongs = phiHoaHongs,
                DuAns = duAns,
                NhanVienSales = nhanVienSales,
                NhanVienSalesId = nhanVienSalesId.Value,
                DuAnId = duAnId.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PhiHoaHong phiHoaHong)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("New", phiHoaHong.PhanCongSanPham.Id);
            }
            if (phiHoaHong.Id == 0)
            {
                phiHoaHong.NgayTao = DateTime.Now;
                _context.PhiHoaHongs.Add(phiHoaHong);
                _context.SaveChanges();
                TempData["success"] = "Cập nhật thành công";
            }
            return RedirectToAction("Index", "QuanLyPhiHoaHong");
        }
    }
}
