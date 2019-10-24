using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RealEstates.Helper;
using RealEstates.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class QuanLyBaoCaoThongKeController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyBaoCaoThongKeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult ThongKeDuAn()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }
            var viewModel = new SalesViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = getAllDuAns(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };

            return View(viewModel);
        }

        public ActionResult Search(int? tinhThanhPhoId, int? quanHuyenId, int? loaiDuAnId, int? trangThai)
        {
            var viewModel = new SalesViewModel {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TrangThaiDuAn = SelectOptions.getTrangThaiDuAn
            };

            viewModel.DuAns = getAllDuAns();

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

        private IEnumerable<DuAnViewModel> getAllDuAns()
        {
            var duAnViewModels = new List<DuAnViewModel>();
            var duAnsInDb = _context.DuAns.Include(x => x.TinhThanhPho).Include(z => z.QuanHuyen).Include(y => y.LoaiDuAn).ToList();
            foreach (var duAn in duAnsInDb)
            {
                var duAnViewModel = new DuAnViewModel(duAn);
                duAnViewModel.LoaiDuAn = duAn.LoaiDuAn;
                duAnViewModel.TinhThanhPho = duAn.TinhThanhPho;
                duAnViewModel.QuanHuyen = duAn.QuanHuyen;
                duAnViewModel.TongSpDaBanHoacChoThue =
                    _context.PhanCongSales.Where(x => x.NhaDat.DuAn.Id == duAn.Id && x.TrangThai == 2).ToList().Count();
                duAnViewModel.TongSpDaTinhHoaHong =
                    _context.PhanCongSales.Where(x => x.NhaDat.DuAn.Id == duAn.Id && x.DaTinhHoaHong).ToList().Count();
                duAnViewModels.Add(duAnViewModel);
            }
            return duAnViewModels;
        }

    }
}