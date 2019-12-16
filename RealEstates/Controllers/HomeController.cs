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
                // lấy dự án mới nhất
                DuAns = _context.DuAns.Include(x => x.LoaiDuAn).Include(y => y.TinhThanhPho)
                    .Where(x => x.TrangThai <= 2)
                    .OrderByDescending(x => x.NgayDang).ToList(),
                // lấy nhà đất mới nhất
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                .Include(x => x.DuAn.TinhThanhPho)
                .ToList().OrderByDescending(x => x.NgayTao).ToList(),
                // lấy tin rao mới nhất
                TinRaoBDSs = _context.TinRaoBDSs.Include(x => x.TinhThanhPho).Include(x => x.LoaiNhaDat)
                    .Where(x => x.TrangThai == 2)
                    .OrderByDescending(x => x.NgayTao).ToList(),

                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                LoaiTimKiems = SelectOptions.getLoaiTimKiem
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            var viewModel = new HomeViewModel
            {
            };
            ViewBag.Title = "Giới thiệu website";
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