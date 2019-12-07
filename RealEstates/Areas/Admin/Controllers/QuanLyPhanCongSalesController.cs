using Microsoft.AspNet.Identity;
using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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

            var phanCongsInDb = _context.PhanCongSales.Include(x => x.NhaDat)
                .Include(x => x.NhaDat.LoaiNhaDat).Include(x => x.NhanVienSales).ToList();
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new DanhSachPhanCongViewModel
            {
                PhanCongSales = phanCongsInDb,
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales,
                DuAns = _context.DuAns.ToList(),
                NhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Search(int? trangThai, int? duAnId, int? nhanVienSalesId)
        {
            var phanCongsInDb = _context.PhanCongSales.Include(x => x.NhaDat)
                .Include(x => x.NhaDat.LoaiNhaDat).Include(x => x.NhanVienSales).ToList();
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new DanhSachPhanCongViewModel
            {
                PhanCongSales = phanCongsInDb,
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

        public ActionResult New()
        {
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new PhanCongSalesViewModel
            {
                NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                && _context.NhaDats.Where(y => y.DuAnId == x.Id).Count() > 0).ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Where(x => _context.PhanCongSales.FirstOrDefault(y => y.NhaDatId == x.Id) == null),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales
            };
            return View("PhanCongSalesForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var phanCongSales = _context.PhanCongSales.Include(x => x.NhaDat).Include(x => x.NhaDat.DuAn).Include(x => x.NhanVienSales).FirstOrDefault(x => x.Id == id);
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
                && _context.NhaDats.Where(y => y.DuAnId == x.Id).Count() > 0).ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Where(x => _context.PhanCongSales.FirstOrDefault(y => y.NhaDatId == x.Id) == null),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales
            };
            viewModel.NhaDat = phanCongSales.NhaDat;
            viewModel.NhanVienSales = phanCongSales.NhanVienSales;
            return View("PhanCongSalesForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var phanCongInDb = _context.PhanCongSales.Include(x => x.NhaDat.DuAn).Include(x => x.NhanVienSales).FirstOrDefault(x => x.Id == id);
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
                    NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                        && x.Account.Roles.FirstOrDefault().RoleId == role.Id).ToList(),
                    DuAns = _context.DuAns.Where(x => x.TrangThai == 1
                    && _context.NhaDats.Where(y => y.DuAnId == x.Id).Count() > 0).ToList(),
                    NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Where(x => _context.PhanCongSales.FirstOrDefault(y => y.NhaDatId == x.Id) == null),
                    TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSales
                };
                return View("PhanCongSalesForm", viewModel);
            }

            if (phanCongSales.Id == 0)
            {
                phanCongSales.TrangThai = 1;
                phanCongSales.NgayTao = DateTime.Now;
                var userId = User.Identity.GetUserId();
                phanCongSales.NguoTao = _context.NhanViens.FirstOrDefault(x => x.AccountId == userId).HoTen;
                _context.PhanCongSales.Add(phanCongSales);
                TempData["success"] = "Thêm thành công";
            }
            else
            {
                var phanCongInDb = _context.PhanCongSales.Single(x => x.Id == phanCongSales.Id);
                phanCongInDb.TrangThai = phanCongSales.TrangThai;
                phanCongInDb.DaTinhHoaHong = phanCongSales.DaTinhHoaHong;
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