using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    [AllowAnonymous]
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
            var viewModel = new DanhSachDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).Include(y => y.LoaiDuAn).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };
            //var viewModel = _context.DuAns.Include(x => x.TinhThanhPho)
            //    .Include(x => x.QuanHuyen).Include(x => x.LoaiDuAn).ToList();
            return View(viewModel);
        }

        public ActionResult List(int id)
        {
            var viewModel = new DanhSachDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).Include(y => y.LoaiDuAn).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };
            //var viewModel = _context.DuAns.Include(x => x.TinhThanhPho)
            //    .Include(x => x.QuanHuyen).Include(x => x.LoaiDuAn).ToList();
            return View(viewModel);
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