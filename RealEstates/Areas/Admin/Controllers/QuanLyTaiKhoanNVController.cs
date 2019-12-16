using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class QuanLyTaiKhoanNVController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public QuanLyTaiKhoanNVController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index()
        {
            var profiles = new List<UserProfileViewModel>();
            var users = _context.Users.Include(u => u.Roles);
            foreach (var user in users)
            {
                var profile = new UserProfileViewModel();
                profile.Id = user.Id;
                profile.Email = user.Email;
                var roleId = user.Roles.First().RoleId;
                profile.RoleName = _context.Roles.SingleOrDefault(r => r.Id == roleId).Name;
                profiles.Add(profile);
            }
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

            return View(profiles);
        }

        public ViewResult New()
        {
            var roles = _context.Roles.ToList();
            var viewModel = new UserProfileViewModel
            {
                Roles = roles
            };

            return View("TaiKhoanForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var user = _context.Users.Include(x => x.Roles).SingleOrDefault(p => p.Id == id);
            var roles = _context.Roles.ToList();

            if (user == null)
            {
                return HttpNotFound();
            }

            var viewModel = new UserProfileViewModel
            {
                Id = user.Id,
                Email = user.Email,
                RoleName = roles.FirstOrDefault(x => x.Id == user.Roles.First().RoleId).Name,
                RoleId = user.Roles.First().RoleId,
                Roles = roles
            };

            return View("TaiKhoanForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa tài khoản của nhân viên đã được phân công bán hàng";
                ExceptionLogger.SendErrorToText(ex);
            }

            return RedirectToAction("Index", "QuanLyTaiKhoanNV");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> SaveAsync(UserProfileViewModel profile)
        {
            if (!ModelState.IsValid)
            {
                var roles = _context.Roles.ToList();
                var viewModel = new UserProfileViewModel
                {
                    Roles = roles
                };
                return View("TaiKhoanForm", viewModel);
            }

            var role = _context.Roles.SingleOrDefault(r => r.Id == profile.RoleId);

            if (string.IsNullOrEmpty(profile.Id))
            {
                var user = new ApplicationUser { UserName = profile.Email, Email = profile.Email };
                var result = await UserManager.CreateAsync(user, profile.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, role.Name);

                    TempData["success"] = "Thêm mới thành công";

                    return RedirectToAction("Index", "QuanLyTaiKhoanNV");
                }
            }
            //else
            //{
            //    var userInDb = _context.Users.SingleOrDefault(u => u.Id == profile.Id);
            //    userInDb.Roles.First().RoleId = profile.RoleId;
            //}

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyTaiKhoanNV");
        }

    }
}