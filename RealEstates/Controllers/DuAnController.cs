using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    public class DuAnController : Controller
    {
        // GET: DuAn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int id)
        {
            return View();
        }
    }
}