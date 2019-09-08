using Microsoft.AspNet.Identity;
using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var viewModel = new UserProfileViewModel
            {
                Email = User.Identity.Name
            };
            return View(viewModel);
        }
    }
}