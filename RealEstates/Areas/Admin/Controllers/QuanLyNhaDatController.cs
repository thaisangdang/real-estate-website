using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RealEstates.ViewModels;
using RealEstates.Helper;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyNhaDatController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyNhaDatController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyNhaDat
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

            var viewModel = new QuanLyNhaDatViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                .Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).ToList()
            };

            return View(viewModel);
        }

        public ActionResult Search(int? tinhThanhPhoId, int? quanHuyenId, int? duAnId)
        {
            var viewModel = new QuanLyNhaDatViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                NhaDats = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                .Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).ToList()
            };

            if (tinhThanhPhoId.HasValue)
            {
                viewModel.TinhThanhPhoId = tinhThanhPhoId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.TinhThanhPho.Id == tinhThanhPhoId);
            }

            if (quanHuyenId.HasValue)
            {
                viewModel.QuanHuyenId = quanHuyenId.Value;
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.QuanHuyen.Id == quanHuyenId);
            }

            if (duAnId.HasValue)
            {
                viewModel.DuAnId = duAnId.Value;
                List<NhaDat> nhaDats = new List<NhaDat>();
                foreach (var item in viewModel.NhaDats)
                {
                    if (item.DuAn != null)
                    {
                        nhaDats.Add(item);
                    }
                }
                viewModel.NhaDats = viewModel.NhaDats.Where(x => x.DuAn.Id == duAnId);
            }

            return View("Index", viewModel);
        }

        public ViewResult New()
        {
            var viewModel = new NhaDatViewModel
            {
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
            };

            return View("NhaDatForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var nhaDat = _context.NhaDats.Include(x => x.LoaiNhaDat).Include(x => x.DuAn)
                .Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).SingleOrDefault(x => x.Id == id);
            if (nhaDat == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NhaDatViewModel(nhaDat)
            {
                DuAns = _context.DuAns.ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
            };

            return View("NhaDatForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var nhaDat = _context.NhaDats.Include(x => x.DuAn).Include(x => x.LoaiNhaDat)
                .Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen).SingleOrDefault(x => x.Id == id);

            if (nhaDat == null)
            {
                return HttpNotFound();
            }

            return View(nhaDat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NhaDat nhaDat)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var viewModel = new NhaDatViewModel
                {
                    DuAns = _context.DuAns.ToList(),
                    LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                    TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                    QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList()
                };
                return View("NhaDatForm", viewModel);
            }

            nhaDat.ThongTinMoTa = HttpUtility.HtmlDecode(nhaDat.ThongTinMoTa);
            nhaDat.Media = HttpUtility.HtmlDecode(nhaDat.Media);
            nhaDat.BanDo = HttpUtility.HtmlDecode(nhaDat.BanDo);

            if (nhaDat.Id == 0)
            {
                nhaDat.NgayTao = DateTime.Now;
                TempData["success"] = "Thêm mới thành công";
                _context.NhaDats.Add(nhaDat);
            }
            else
            {
                var nhaDatInDb = _context.NhaDats.Single(x => x.Id == nhaDat.Id);
                nhaDatInDb.DuAnId = nhaDat.DuAnId;
                nhaDatInDb.IsRent = nhaDat.IsRent;
                nhaDatInDb.LoaiNhaDatId = nhaDat.LoaiNhaDatId;
                nhaDatInDb.TinhThanhPhoId = nhaDat.LoaiNhaDatId;
                nhaDatInDb.QuanHuyenId = nhaDat.QuanHuyenId;
                nhaDatInDb.DiaChi = nhaDat.DiaChi;
                nhaDatInDb.GiaBan = nhaDat.GiaBan;
                nhaDatInDb.GiaThue = nhaDat.GiaThue;
                nhaDatInDb.DienTich = nhaDat.DienTich;
                nhaDatInDb.HuongNha = nhaDat.HuongNha;
                nhaDatInDb.SoPhong = nhaDat.SoPhong;
                nhaDatInDb.ThongTinMoTa = nhaDat.ThongTinMoTa;
                nhaDatInDb.Media = nhaDat.Media;
                nhaDatInDb.TuKhoa = nhaDat.TuKhoa;
                nhaDatInDb.BanDo = nhaDat.BanDo;
                nhaDatInDb.NgayTao = nhaDat.NgayTao;
                TempData["success"] = "Cập nhật thành công";
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLyNhaDat");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var nhaDat = _context.NhaDats.Single(x => x.Id == id);
            try
            {
                _context.NhaDats.Remove(nhaDat);
                _context.SaveChanges();
                TempData["success"] = "Xóa thành công";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Không thể xóa nhà đất đã phân công cho sales hoặc đã bán/cho thuê";
                ExceptionLogger.SendErrorToText(ex);
            }

            return RedirectToAction("Index", "QuanLyNhaDat");
        }
    }
}
