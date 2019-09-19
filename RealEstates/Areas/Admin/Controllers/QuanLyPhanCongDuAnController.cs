using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class QuanLyPhanCongDuAnController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhanCongDuAnController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhanCongDuAn
        public ActionResult Index()
        {
            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"].ToString();
                TempData.Remove("success");
            }
            var viewModel = new QuanLyPhanCongDuAnViewModel
            {
                LoaiDuAns = _context.LoaiDuAns.ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                DuAns = _context.DuAns.Include(x => x.TinhThanhPho).Include(y => y.LoaiDuAn).ToList()
            };

            return View(viewModel);
        }

        public ActionResult Search(int? tinhThanhPhoId, int? quanHuyenId, int? loaiDuAnId)
        {
            var viewModel = new QuanLyPhanCongDuAnViewModel();
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

            viewModel.TinhThanhPhos = _context.TinhThanhPhos.ToList();
            viewModel.QuanHuyens = _context.QuanHuyens.ToList();
            viewModel.LoaiDuAns = _context.LoaiDuAns.ToList();

            return View("Index", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var duAn = _context.DuAns.SingleOrDefault(x => x.Id == id);

            var viewModel = new QuanLyPhanCongDuAnViewModel
            {

            };

            return View(viewModel);
        }
    }
}