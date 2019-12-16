using RealEstates.Helper;
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
                .Include(x => x.DuAn.TinhThanhPho).Include(x => x.DuAn.QuanHuyen).ToList(),
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
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
                    .Include(x => x.DuAn.TinhThanhPho).Include(x => x.DuAn.QuanHuyen).ToList(),
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
            };

            //if (keyWord != null)
            //{
            //    viewModel.KeyWord = keyWord;
            //    viewModel.NhaDats = viewModel.NhaDats.Where(x => x.Ten.Contains(keyWord) || x.ThongTinMoTa.Contains(keyWord)
            //    || x.TuKhoa.Contains(keyWord) || x.DuAn.TenDuAn.Contains(keyWord) || x.LoaiNhaDat.TenLoai.Contains(keyWord));
            //}

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                viewModel.KeyWord = keyWord;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.ThongTinMoTa.Contains(keyWord));
            }

            if (loaiNhaDatId.HasValue)
            {
                viewModel.LoaiNhaDatId = loaiNhaDatId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.LoaiNhaDat.Id == loaiNhaDatId.Value);
            }

            if (tinhThanhPhoId.HasValue)
            {
                viewModel.TinhThanhPhoId = tinhThanhPhoId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DuAn.TinhThanhPho.Id == tinhThanhPhoId.Value);
            }

            if (quanHuyenId.HasValue)
            {
                viewModel.QuanHuyenId = quanHuyenId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DuAn.QuanHuyen.Id == quanHuyenId.Value);
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

            //return View("~/Views/NhaDat/Index.cshtml", viewModel);
            return View("Index", viewModel);
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
                    .Where(x => x.LoaiNhaDat.Id == loaiNhaDat && x.IsRent == isRent).ToList(),
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
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
                    .Where(x => x.DuAn.Id == duAnId).ToList(),
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
            };
            return View("Index", viewModel);
        }
    }
}
