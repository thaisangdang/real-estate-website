using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RealEstates.ViewModels;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyTinRaoController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyTinRaoController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyTinRao
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }
            if (TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"].ToString();
                TempData.Remove("error");
            }

            var viewModel = new QuanLyTinRaoViewModel
            {
                TinRaoBDSs = _context.TinRaoBDSs.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var tinRao = _context.TinRaoBDSs.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen)
                .SingleOrDefault(x => x.Id == id);

            if (tinRao == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TinRaoViewModel(tinRao);

            return View("Details", viewModel);
        }
    }
}
