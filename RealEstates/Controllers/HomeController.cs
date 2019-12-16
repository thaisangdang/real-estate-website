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
                    .OrderByDescending(x => x.NgayDang).ToList(),
                // lấy nhà đất mới nhất
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                .Include(x => x.DuAn.TinhThanhPho)
                .ToList().OrderByDescending(x => x.NgayTao).ToList(),
                // lấy tin rao mới nhất
                TinRaoBDSs = _context.TinRaoBDSs.Include(x => x.TinhThanhPho).Include(x => x.LoaiNhaDat).ToList()
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

        public ActionResult Search(string keyWord, int? loaiNhaDatId, int? tinhThanhPhoId, int? quanHuyenId, int? dienTichId, int? khoangGiaId)
        {
            var viewModel = new DanhSachNhaDatViewModel
            {
                DuAns = _context.DuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                    .Include(x => x.DuAn.TinhThanhPho).Include(x => x.DuAn.QuanHuyen).ToList()
            };

            if (keyWord != null)
            {
                viewModel.KeyWord = keyWord;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.Ten.Contains(keyWord) || x.ThongTinMoTa.Contains(keyWord)
                || x.TuKhoa.Contains(keyWord) || x.DuAn.TenDuAn.Contains(keyWord) || x.LoaiNhaDat.TenLoai.Contains(keyWord));
            }

            if (loaiNhaDatId.HasValue)
            {
                viewModel.LoaiDuAnId = loaiNhaDatId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.LoaiNhaDat.Id == loaiNhaDatId);
            }

            if (tinhThanhPhoId.HasValue)
            {
                viewModel.TinhThanhPhoId = tinhThanhPhoId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DuAn.TinhThanhPho.Id == tinhThanhPhoId);
            }

            if (quanHuyenId.HasValue)
            {
                viewModel.QuanHuyenId = quanHuyenId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DuAn.QuanHuyen.Id == quanHuyenId);
            }

            if (dienTichId.HasValue)
            {
                viewModel.DienTichId = dienTichId.Value;
                switch (dienTichId)
                {
                    case 1:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DienTich < 20);
                        break;

                    case 2:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DienTich >= 20 && x.DienTich <= 50);
                        break;

                    case 3:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DienTich >= 50 && x.DienTich <= 100);
                        break;

                    case 4:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DienTich > 100);
                        break;
                }
            }

            if (khoangGiaId.HasValue)
            {
                viewModel.KhoangGiaId = khoangGiaId.Value;
                switch (khoangGiaId)
                {
                    case 1:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => (x.IsRent && x.GiaThue < 2000000));
                        break;

                    case 2:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => (x.IsRent && x.GiaThue >= 2000000) || (x.IsRent && x.GiaThue <= 5000000));
                        break;

                    case 3:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => (x.IsRent && x.GiaThue > 5000000) || (!x.IsRent && x.GiaBan > 5000000));
                        break;

                    case 4:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => (x.IsRent && x.GiaThue < 500000000) || (!x.IsRent && x.GiaBan < 500000000));
                        break;

                    case 5:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => ((x.IsRent && x.GiaThue >= 500000000) && (x.IsRent && x.GiaThue < 2000000000))
                        || ((!x.IsRent && x.GiaBan >= 500000000) && (!x.IsRent && x.GiaBan < 2000000000)));
                        break;

                    case 6:
                        viewModel.NhaDats = viewModel.NhaDats.Where(x => (!x.IsRent && x.GiaBan > 2000000000));
                        break;
                }
            }

            return View("~/Views/NhaDat/Index.cshtml", viewModel);
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