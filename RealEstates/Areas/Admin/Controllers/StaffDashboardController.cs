using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Staff)]
    public class StaffDashboardController : Controller
    {
        // GET: Admin/StaffDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}