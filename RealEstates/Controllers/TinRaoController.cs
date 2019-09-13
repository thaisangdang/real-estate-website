using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    public class TinRaoController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public TinRaoController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: TinRao
        public ActionResult Index(string loaiTinRao)
        {

            return View();
        }
    }
}