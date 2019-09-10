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
    public class QuanLyPhiHoaHongController : Controller
    {
        // GET: Admin/QuanLyPhiHoaHong
        public ActionResult Index()
        {
            return View();
        }
    }
}