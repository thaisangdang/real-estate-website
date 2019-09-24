using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RealEstates.Helper;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class QuanLyPhanCongSanPhamController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhanCongSanPhamController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhanCongSanPham
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }
            var viewModel = new QuanLyPhanCongSanPhamViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(y => y.LoaiDuAn).ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };

            return View(viewModel);
        }

        public ActionResult Search(int? tinhThanhPhoId, int? quanHuyenId, int? loaiDuAnId, int? trangThai)
        {
            var viewModel = new QuanLyPhanCongSanPhamViewModel {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };

            viewModel.DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(y => y.LoaiDuAn).ToList();

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

            if (trangThai.HasValue)
            {
                viewModel.TrangThai = trangThai.Value;
                viewModel.DuAns = viewModel.DuAns.Where(x => x.TrangThai == trangThai);
            }

            return View("Index", viewModel);
        }



        public ActionResult ThongBao(int id)
        {
            var duAn = _context.DuAns.SingleOrDefault(x => x.Id == id);

            var viewModel = new QuanLyPhanCongSanPhamViewModel
            {

            };

            return View(viewModel);
        }

        public ActionResult New()
        {

            return View("PhanCongSanPhamForm");
        }
    }
}