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

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class SalesController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public SalesController()
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
                    _context.PhanCongSanPhams.Where(x => x.DuAnId == duAn.Id && x.TrangThai == 2).ToList().Count();
                duAnViewModel.TongSpDaTinhHoaHong =
                    _context.PhanCongSanPhams.Where(x => x.DuAnId == duAn.Id && x.DaTinhHoaHong).ToList().Count();
                duAnViewModels.Add(duAnViewModel);
            }
            return duAnViewModels;
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

        // list phân công sản phẩm được thông báo hoàn thành
        public ActionResult ThongBao(int duAnId)
        {
            var duAn = _context.DuAns.SingleOrDefault(x => x.Id == duAnId);

            var viewModel = new SalesViewModel
            {

            };

            return View(viewModel);
        }

        // form phân công sản phẩm cho nhân viên sales
        public ActionResult New()
        {
            var role = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
            var viewModel = new PhanCongSanPhamViewModel
            {
                // nhân viên đang làm việc, có tài khoản phân quyền là sales, không quan tâm phòng ban
                NhanViens = _context.NhanViens.Where(x => x.TrangThai == 1
                    && x.Account.Roles.First().RoleId == role.Id).ToList(),
                // Dự án có trạng thái đang mở bán và số sản phẩm >0
                DuAns = _context.DuAns.Where(x => x.TrangThai == 1 && x.SoSanPham > 0).ToList(),
                TrangThaiPhanCong = SelectOptions.getTrangThaiPhanCongSanPham
            };

            return View("PhanCongSanPhamForm", viewModel);
        }

        // list những sản phẩm đã phân công cho nhân viên sales với trạng thái
        // chưa hoàn thành, đã hoàn thành, đã tính hoa hồng, chưa tính hoa hồng
        public ActionResult Sales(int duAnId)
        {

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PhanCongSanPham phanCongSanPham)
        {
            return View();
        }
    }
}