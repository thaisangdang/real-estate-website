using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminDashboardController : Controller
    {
        // GET: Admin/AdminDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}