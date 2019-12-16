using RealEstates.Models;
using RealEstates.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    [AllowAnonymous]
    public class NhaDatController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public NhaDatController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: NhaDat
        public ActionResult Index()
        {
            var viewModel = new DanhSachNhaDatViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                .Include(x => x.DuAn.TinhThanhPho).Include(x => x.DuAn.QuanHuyen).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var nhaDat = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn).Include(x => x.DuAn.TinhThanhPho)
                .Include(x => x.DuAn.LoaiDuAn).Include(x => x.DuAn.QuanHuyen).SingleOrDefault(x => x.Id == id);
            return View(nhaDat);
        }

        public ActionResult List(int? loaiNhaDat, bool? isRent)
        {
            var viewModel = new DanhSachNhaDatViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                    .Include(x => x.DuAn.TinhThanhPho).Include(x => x.DuAn.QuanHuyen)
                    .Where(x => x.LoaiNhaDat.Id == loaiNhaDat && x.IsRent == isRent).ToList()
            };
            return View("Index", viewModel);
        }

        public ActionResult GetNhaDatByDuAn(int? duAnId)
        {
            if (!duAnId.HasValue)
            {
                return HttpNotFound();
            }
            var viewModel = new DanhSachNhaDatViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                    .Include(x => x.DuAn.TinhThanhPho).Include(x => x.DuAn.QuanHuyen)
                    .Where(x => x.DuAn.Id == duAnId).ToList()
            };
            return View("Index", viewModel);
        }
    }
}
