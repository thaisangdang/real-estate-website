﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    public class TinRaoController : Controller
    {
        // GET: TinRao
        public ActionResult Index(string loaiTinRao)
        {
            return View();
        }
    }
}