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
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyPhanCongSalesController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhanCongSalesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhanCongSales
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

            var phanCongsInDb = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhanVienSales).ToList();
            var phanCongViewModels = new List<PhanCongSalesViewModel>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSalesViewModel(phanCongInDb);
                phanCong.NhaDat = phanCongInDb.NhaDat;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new DanhSachPhanCongViewModel
            {
                PhanCongSales = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales,
                DuAns = _context.DuAns.ToList(),
                NhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Search(int? trangThai, int? duAnId, int? nhanVienSalesId)
        {
            var phanCongsInDb = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhaDat.DuAn.Id).Include(x => x.NhanVienSales).ToList();
            var phanCongViewModels = new List<PhanCongSalesViewModel>();
            foreach (var phanCongInDb in phanCongsInDb)
            {
                var phanCong = new PhanCongSalesViewModel(phanCongInDb);
                phanCong.NhaDat = phanCongInDb.NhaDat;
                phanCong.NhanVienSales = phanCongInDb.NhanVienSales;
                phanCongViewModels.Add(phanCong);
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new DanhSachPhanCongViewModel
            {
                PhanCongSales = phanCongViewModels,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales,
                DuAns = _context.DuAns.ToList(),
                NhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList()
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

            if (nhanVienSalesId.HasValue)
            {
                viewModel.NhanVienSalesId = nhanVienSalesId.Value;
                viewModel.PhanCongSales = viewModel.PhanCongSales.Where(x => x.NhanVienSales.Id == nhanVienSalesId);
            }

            return View("Index", viewModel);
        }

        // form phân công nhà đất cho nhân viên sales
        public ActionResult New()
        {
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new PhanCongSalesViewModel
            {
                // nhân viên đang làm việc, có tài khoản phân quyền là sales, không quan tâm phòng ban
                NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                // Dự án có trạng thái đang mở bán và tổng số sản phẩm > số sản phẩm đã bán hoặc cho thuê
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                    && x.SoSanPham > _context.PhanCongSales.Where(y => y.NhaDat.DuAn.Id == x.Id).Count()).ToList(),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales
            };
            return View("PhanCongSalesForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var phanCongSales = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhaDat.DuAn).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongSales == null)
            {
                return HttpNotFound();
            }
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new PhanCongSalesViewModel(phanCongSales)
            {
                NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                    && x.SoSanPham > _context.PhanCongSales.Where(y => y.NhaDat.DuAn.Id == x.Id).Count()).ToList(),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales
            };
            viewModel.NhaDat.DuAn = phanCongSales.NhaDat.DuAn;
            viewModel.NhanVienSales = phanCongSales.NhanVienSales;
            return View("PhanCongSalesForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var phanCongInDb = _context.PhanCongSales.Include(x => x.NhaDat.DuAn).Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
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
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new PhanCongSalesViewModel
                {
                    // nhân viên đang làm việc, có tài khoản phân quyền là sales, không quan tâm phòng ban
                    NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                        && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                    // Dự án có trạng thái đang mở bán và tổng số sản phẩm > số sản phẩm đã bán hoặc cho thuê
                    DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                        && x.SoSanPham > _context.PhanCongSales.Where(y => y.NhaDat.DuAn.Id == x.Id).Count()).ToList(),
                    TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales
                };
                return View("PhanCongSalesForm", viewModel);
            }

            if (phanCongSales.Id == 0)
            {
                phanCongSales.TrangThai = 1;
                phanCongSales.NgayTao = DateTime.Now;
                var userId = User.Identity.GetUserId();
                phanCongSales.NguoTao = _context.NhanViens.SingleOrDefault(x => x.AccountId == userId).HoTen;
                _context.PhanCongSales.Add(phanCongSales);
                TempData["success"] = "Thêm thành công";
            }
            else
            {
                var phanCongInDb = _context.PhanCongSales.Single(x => x.Id == phanCongSales.Id);
                //phanCongInDb.DuAnId = phanCongSales.DuAnId;
                //phanCongInDb.SanPham = phanCongSales.SanPham;
                //phanCongInDb.GiaBanSanPham = phanCongSales.GiaBanSanPham;
                //phanCongInDb.PhanTramHoaHong = phanCongSales.PhanTramHoaHong;
                //phanCongInDb.IsRent = phanCongSales.IsRent;
                //phanCongInDb.GiaThueThangDau = phanCongSales.GiaThueThangDau;
                //phanCongInDb.NhanVienSalesId = phanCongSales.NhanVienSalesId;
                phanCongInDb.TrangThai = phanCongSales.TrangThai;
                //phanCongInDb.DaTinhHoaHong = phanCongSales.DaTinhHoaHong;
                TempData["success"] = "Cập nhật thành công";
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyPhanCongSales");
        }

        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return HttpNotFound();
            }
            var phanCongSP = _context.PhanCongSales.Single(x => x.Id == id);
            try
            {
                _context.PhanCongSales.Remove(phanCongSP);
                _context.SaveChanges();
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa phân công đã tính hoa hồng";
                ExceptionLogger.SendErrorToText(ex);
            }

            return RedirectToAction("Index", "QuanLyPhanCongSales");
        }
    }
}