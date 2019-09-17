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
    [Authorize(Roles = "Administrator, SalesMan, Staff")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrator))
            {
                return RedirectToAction("Index", "AdminDashboard");
            }
            else if (User.IsInRole(RoleName.SalesMan))
            {
                return RedirectToAction("Index", "SalesManDashboard");
            }
            return RedirectToAction("Index", "StaffDashboard");
        }
    }
}