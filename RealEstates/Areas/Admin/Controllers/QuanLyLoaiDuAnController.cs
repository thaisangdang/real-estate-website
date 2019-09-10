using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyLoaiDuAnController : Controller
    {
        // GET: Admin/QuanLyLoaiDuAn
        public ActionResult Index()
        {
            return View();
        }
    }
}