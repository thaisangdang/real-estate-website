using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RealEstates.Helper;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class QuanLyNhanVienController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyNhanVienController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyNhanVien
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }
            var viewModel = new QuanLyNhanVienViewModel
            {
                NhanViens = _context.NhanViens.Include(x => x.PhongBan).Include(z => z.Account).ToList(),
                Roles = _context.Roles.ToList(),
                TrangThaiNhanVien = SelectOptions.getTrangThaiNhanVien
            };
            return View(viewModel);
        }

        public ActionResult Search(string roleId)
        {
            var viewModel = new QuanLyNhanVienViewModel
            {
                NhanViens = _context.NhanViens.Include(x => x.PhongBan).Include(z => z.Account)
                .Where(nv => nv.Account.Roles.FirstOrDefault().RoleId == roleId)
                .ToList(),
                Roles = _context.Roles.ToList(),
                TrangThaiNhanVien = SelectOptions.getTrangThaiNhanVien
            };

            return View("Index", viewModel);
        }

        public ViewResult New()
        {
            var nhanViens = _context.NhanViens.Include(x => x.Account).ToList();
            var accountIdsHasUser = new List<string>();
            foreach (var item in nhanViens)
            {
                accountIdsHasUser.Add(item.Account.Id);
            }
            var viewModel = new NhanVienViewModel()
            {
                // lấy list tài khoản chưa cấp cho nhân viên
                Accounts = _context.Users.Where(x => !accountIdsHasUser.Contains(x.Id)).ToList(),
                PhongBans = _context.PhongBans.ToList(),
                TrangThaiNhanVien = SelectOptions.getTrangThaiNhanVien
            };
            return View("NhanVienForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var nhanVien = _context.NhanViens.Include(x => x.Account).SingleOrDefault(x => x.Id == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            var nhanViens = _context.NhanViens.Include(x => x.Account).ToList();
            var accountIdsHasUser = new List<string>();
            foreach (var item in nhanViens)
            {
                accountIdsHasUser.Add(item.Account.Id);
            }
            var viewModel = new NhanVienViewModel(nhanVien)
            {
                // lấy list tài khoản chưa cấp cho nhân viên
                Accounts = _context.Users.Where(x => !accountIdsHasUser.Contains(x.Id)).ToList(),
                PhongBans = _context.PhongBans.ToList(),
                TrangThaiNhanVien = SelectOptions.getTrangThaiNhanVien
            };
            // cộng với tài khoản hiện tại của nhân viên đó
            viewModel.Accounts.Add(nhanVien.Account);

            return View("NhanVienForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var nhanVien = _context.NhanViens.Include(x => x.PhongBan).Include(y => y.Account).SingleOrDefault(x => x.Id == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new NhanVienViewModel
                {
                    Accounts = _context.Users.ToList(),
                    PhongBans = _context.PhongBans.ToList(),
                    TrangThaiNhanVien = SelectOptions.getTrangThaiNhanVien
                };
                return View("NhanVienForm", viewModel);
            }

            if (nhanVien.Id == 0)
            {
                _context.NhanViens.Add(nhanVien);
                TempData["success"] = "Thêm thành công";
            }
            else
            {
                var nhanVienInDb = _context.NhanViens.Single(x => x.Id == nhanVien.Id);
                nhanVienInDb.HoTen = nhanVien.HoTen;
                nhanVienInDb.Email = nhanVien.Email;
                nhanVienInDb.PhongBanId = nhanVien.PhongBanId;
                nhanVienInDb.AccountId = nhanVien.AccountId;
                nhanVienInDb.TrangThai = nhanVien.TrangThai;
                TempData["success"] = "Cập nhật thành công";
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyNhanVien");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var nhanVien = _context.NhanViens.Single(x => x.Id == id);
            try
            {
                _context.NhanViens.Remove(nhanVien);
                _context.SaveChanges();
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa nhân viên đã có thông tin trong dự án";
                ExceptionLogger.SendErrorToText(ex);
            }

            return RedirectToAction("Index", "QuanLyNhanVien");
        }
    }
}