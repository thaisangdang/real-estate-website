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
            return View(viewModel);
        }

        public ActionResult Search(string keyWord, int? tinhThanhPhoId, int? quanHuyenId, int? loaiDuAnId)
        {
            var viewModel = new DanhSachDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).Include(y => y.LoaiDuAn).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };


            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                viewModel.KeyWord = keyWord;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.GioiThieuDuAn.Contains(keyWord));
            }

            if (tinhThanhPhoId.HasValue)
            {
                viewModel.TinhThanhPhoId = tinhThanhPhoId.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.TinhThanhPho.Id == tinhThanhPhoId);
            }

            if (quanHuyenId.HasValue)
            {
                viewModel.QuanHuyenId = quanHuyenId.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.QuanHuyen.Id == quanHuyenId);
            }

            if (loaiDuAnId.HasValue)
            {
                viewModel.LoaiDuAnId = loaiDuAnId.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.LoaiDuAn.Id == loaiDuAnId);
            }

            return View("Index", viewModel);
        }

        public ActionResult List(int id)
        {
            var viewModel = new DanhSachDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).Include(y => y.LoaiDuAn)
                .Where(x => x.LoaiDuAn.Id == id).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn,
                LoaiDuAnId = id
            };
            return View("Index", viewModel);
        }

        public ActionResult GetDuAnByDoanhNghiep(int? doanhNghiepId)
        {
            var viewModel = new DanhSachDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen)
                .Include(y => y.LoaiDuAn).Include(x => x.DoanhNghiepBDS)
                .Where(x => x.DoanhNghiepBDS.Id == doanhNghiepId).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn,
            };
            return View("Index", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var duAn = _context.DuAns.Include(x => x.DoanhNghiepBDS).Include(x => x.LoaiDuAn)
                .SingleOrDefault(x => x.Id == id);
            return View(duAn);
        }
    }
}