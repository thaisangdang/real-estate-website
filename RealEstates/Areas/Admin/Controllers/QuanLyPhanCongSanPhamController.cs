using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class QuanLyPhanCongSanPhamController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhanCongSanPhamController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhanCongSanPham
        public ActionResult Index()
        {
            // list những sản phẩm đã phân công cho nhân viên sales với trạng thái
            // chưa hoàn thành, đã hoàn thành, đã tính hoa hồng, chưa tính hoa hồng, có bộ lọc các trạng thái trên
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }

            var phanCongsInDb = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales).ToList();
            var phanCongViewModels = new List<PhanCongSanPhamViewModel>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSanPhamViewModel(phanCongInDb);
                phanCong.DuAn = phanCongInDb.DuAn;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new DanhSachPhanCongViewModel
            {
                PhanCongSanPhams = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham,
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1).ToList(),
                NhanVienSales = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Search(int? trangThai, int? duAnId, int? nhanVienSalesId)
        {
            var phanCongsInDb = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales).ToList();
            var phanCongViewModels = new List<PhanCongSanPhamViewModel>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSanPhamViewModel(phanCongInDb);
                phanCong.DuAn = phanCongInDb.DuAn;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new DanhSachPhanCongViewModel
            {
                PhanCongSanPhams = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham,
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1).ToList(),
                NhanVienSales = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList()
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

            if (nhanVienSalesId.HasValue)
            {
                viewModel.NhanVienSalesId = nhanVienSalesId.Value;
                viewModel.PhanCongSanPhams = viewModel.PhanCongSanPhams.Where(x => x.NhanVienSales.Id == nhanVienSalesId);
            }

            return View("Index", viewModel);
        }

        // form phân công sản phẩm cho nhân viên sales
        public ActionResult New()
        {
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new PhanCongSanPhamViewModel
            {
                // nhân viên đang làm việc, có tài khoản phân quyền là sales, không quan tâm phòng ban
                NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                // Dự án có trạng thái đang mở bán và tổng số sản phẩm > số sản phẩm đã bán hoặc cho thuê
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                    && x.SoSanPham > _context.PhanCongSanPhams.Where(y => y.DuAnId == x.Id).Count()).ToList(),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham
            };
            return View("PhanCongSanPhamForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var phanCongSanPham = _context.PhanCongSanPhams.Include(x => x.DuAn).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongSanPham == null)
            {
                return HttpNotFound();
                // Dự án có trạng thái đang mở bán và tổng số sản phẩm > số sản phẩm đã bán hoặc cho thuê
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new PhanCongSanPhamViewModel(phanCongSanPham)
            {
                // nhân viên đang làm việc, có tài khoản phân quyền là sales, không quan tâm phòng ban
                NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                    && x.SoSanPham > _context.PhanCongSanPhams.Where(y => y.DuAnId == x.Id).Count()).ToList(),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham
            };
            return View("PhanCongSanPhamForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PhanCongSanPham phanCongSanPham)
        {
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            if (!ModelState.IsValid)
            {
                var viewModel = new PhanCongSanPhamViewModel
                {
                    // nhân viên đang làm việc, có tài khoản phân quyền là sales, không quan tâm phòng ban
                    NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                        && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                    // Dự án có trạng thái đang mở bán và tổng số sản phẩm > số sản phẩm đã bán hoặc cho thuê
                    DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                        && x.SoSanPham > _context.PhanCongSanPhams.Where(y => y.DuAnId == x.Id).Count()).ToList(),
                    TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham
                };
                return View("PhanCongSanPhamForm", viewModel);
            }

            if (phanCongSanPham.Id == 0)
            {
                phanCongSanPham.TrangThai = 1;
                phanCongSanPham.NgayTao = DateTime.Now;
                var userId = User.Identity.GetUserId();
                phanCongSanPham.NguoTao = _context.NhanViens.SingleOrDefault(x => x.AccountId == userId).HoTen;
                _context.PhanCongSanPhams.Add(phanCongSanPham);
                TempData["success"] = "Thêm thành công";
            }
            else
            {
                var phanCongInDb = _context.PhanCongSanPhams.Single(x => x.Id == phanCongSanPham.Id);
                phanCongInDb.DuAnId = phanCongSanPham.DuAnId;
                phanCongInDb.SanPham = phanCongSanPham.SanPham;
                phanCongInDb.GiaBanSanPham = phanCongSanPham.GiaBanSanPham;
                phanCongInDb.PhanTramHoaHong = phanCongSanPham.PhanTramHoaHong;
                phanCongInDb.IsRent = phanCongSanPham.IsRent;
                phanCongInDb.GiaThueThangDau = phanCongSanPham.GiaThueThangDau;
                phanCongInDb.NhanVienSalesId = phanCongSanPham.NhanVienSalesId;
                phanCongInDb.TrangThai = phanCongSanPham.TrangThai;
                phanCongInDb.DaTinhHoaHong = phanCongSanPham.DaTinhHoaHong;
                TempData["success"] = "Cập nhật thành công";
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyPhanCongSanPham");
        }
    }
}