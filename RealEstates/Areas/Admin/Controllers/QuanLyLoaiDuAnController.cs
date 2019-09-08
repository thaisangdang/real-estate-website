﻿using RealEstates.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Areas.Admin.Controllers
{
    public class QuanLyLoaiDuAnController : Controller
    {
        // GET: Admin/QuanLyLoaiDuAn
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