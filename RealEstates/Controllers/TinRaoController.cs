using RealEstates.Helper;
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

        [Authorize]
        public ActionResult New()
        {
            var viewModel = new TinRaoViewModel
            {
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao,
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS
            };

            return View("TinRaoForm", viewModel);
        }
    }
}