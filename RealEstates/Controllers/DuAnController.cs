using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    public class DuAnController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public DuAnController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: DuAn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int id)
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var duAn = _context.DuAns.SingleOrDefault(x => x.Id == id);
            return View(duAn);
        }
    }
}