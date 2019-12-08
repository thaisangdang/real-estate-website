using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                DuAns = _context.DuAns.Include(x => x.LoaiDuAn).Include(y => y.TinhThanhPho).ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                TinhThanhPhos = _context.TinhThanhPhos.ToList()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            var viewModel = new HomeViewModel
            {
            };

            return View(viewModel);
        }

        public ActionResult Contact()
        {
            var viewModel = new HomeViewModel
            {
            };

            return View(viewModel);
        }
    }
}