using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class QuanLyPhanCongDuAnController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhanCongDuAnController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhanCongDuAn
        public ActionResult Index()
        {
            var viewModel = new PhanCongDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(y => y.LoaiDuAn).ToList()
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var duAn = _context.DuAns.SingleOrDefault(x => x.Id == id);

            var viewModel = new PhanCongDuAnViewModel
            {

            };

            return View(viewModel);
        }
    }
}