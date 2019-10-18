﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyTinRaoController : Controller
    {
        // GET: Admin/QuanLyTinRao
        public ActionResult Index()
        {
            return View();
        }
    }
}