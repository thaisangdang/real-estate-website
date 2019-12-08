using Microsoft.AspNet.Identity;
using RealEstates.Areas.Admin.Models;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace RealEstates.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, SalesMan, Staff")]
    public class QuanLyPhiHoaHongController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public QuanLyPhiHoaHongController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/QuanLyPhiHoaHong
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

            var duAns = new List<DuAn>();
            var nhanVienSales = new List<NhanVien>();
            var phiHoaHongs = new List<PhiHoaHong>();

            if (User.IsInRole(RoleName.SalesMan))
            {
                var salesManAccountId = User.Identity.GetUserId();
                var salesMan = _context.NhanViens.SingleOrDefault(x => x.Account.Id == salesManAccountId);
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSales).Include(x => x.PhanCongSales.NhanVienSales)
                    .Include(X => X.PhanCongSales.NhaDat.DuAn).Include(x => x.PhanCongSales.NhaDat.LoaiNhaDat)
                    .Where(x => x.PhanCongSales.NhanVienSales.Id == salesMan.Id).ToList();
                foreach (var item in phiHoaHongs)
                {
                    duAns.Add(item.PhanCongSales.NhaDat.DuAn);
                }
                nhanVienSales.Add(salesMan);
            }
            else
            {
                var salesRole = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
                nhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == salesRole.Id).ToList();
                duAns = _context.DuAns.ToList();
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSales).Include(x => x.PhanCongSales.NhanVienSales)
                    .Include(X => X.PhanCongSales.NhaDat.DuAn).Include(x => x.PhanCongSales.NhaDat.LoaiNhaDat).ToList();
            }

            var viewModel = new QuanLyPhiHoaHongViewModel
            {
                PhiHoaHongs = phiHoaHongs,
                DuAns = duAns,
                NhanVienSales = nhanVienSales
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New(int id)
        {
            var phanCongSales = _context.PhanCongSales.Include(x => x.NhaDat.DuAn).Include(x => x.NhaDat.LoaiNhaDat)
                .Include(x => x.NhanVienSales).SingleOrDefault(x => x.Id == id);
            if (phanCongSales == null)
                return HttpNotFound();

            var userId = User.Identity.GetUserId();
            var phiHoaHong = new PhiHoaHong();
            phiHoaHong.PhanCongSalesId = phanCongSales.Id;
            phiHoaHong.NguoiTaoId = _context.NhanViens.SingleOrDefault(x => x.Account.Id == userId).Id;
            var viewModel = new PhiHoaHongViewModel(phiHoaHong)
            {
                NhanVienSales = phanCongSales.NhanVienSales.HoTen,
                TenDuAn = phanCongSales.NhaDat.DuAn.TenDuAn,
                NhaDat = phanCongSales.NhaDat,
                IsRent = phanCongSales.NhaDat.LoaiNhaDat.IsRent,
                GiaThue = phanCongSales.NhaDat.GiaThue,
                GiaBan = phanCongSales.NhaDat.GiaBan,
                PhanTramHoaHong = phanCongSales.PhanTramHoaHong
            };

            if (phanCongSales.NhaDat.LoaiNhaDat.IsRent)
                viewModel.TongChi = phanCongSales.NhaDat.GiaThue * (decimal)(phanCongSales.PhanTramHoaHong / 100);
            else
                viewModel.TongChi = phanCongSales.NhaDat.GiaBan * (decimal)(phanCongSales.PhanTramHoaHong / 100);

            return View("PhiHoaHongForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var phiHoaHong = _context.PhiHoaHongs.Include(x => x.PhanCongSales).Include(x => x.PhanCongSales.NhanVienSales)
                .Include(X => X.PhanCongSales.NhaDat.DuAn).Include(x => x.PhanCongSales.NhaDat.LoaiNhaDat).SingleOrDefault(x => x.Id == id);
            if (phiHoaHong == null)
                return HttpNotFound();
            return View(phiHoaHong);
        }

        public ActionResult Search(int? duAnId, int? nhanVienSalesId)
        {
            var duAns = new List<DuAn>();
            var nhanVienSales = new List<NhanVien>();
            var phiHoaHongs = new List<PhiHoaHong>();

            if (User.IsInRole(RoleName.SalesMan))
            {
                var salesManAccountId = User.Identity.GetUserId();
                var salesMan = _context.NhanViens.SingleOrDefault(x => x.Account.Id == salesManAccountId);
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSales).Include(x => x.PhanCongSales.NhanVienSales)
                    .Include(X => X.PhanCongSales.NhaDat.DuAn).Include(X => X.PhanCongSales.NhaDat.LoaiNhaDat)
                    .Where(x => x.PhanCongSales.NhanVienSales.Id == salesMan.Id).ToList();
                foreach (var item in phiHoaHongs)
                {
                    duAns.Add(item.PhanCongSales.NhaDat.DuAn);
                }
                nhanVienSales.Add(salesMan);
            }
            else
            {
                var salesRole = _context.Roles.Single(x => x.Name == RoleName.SalesMan);
                nhanVienSales = _context.NhanViens.Where(x => x.Account.Roles.FirstOrDefault().RoleId == salesRole.Id).ToList();
                duAns = _context.DuAns.ToList();
                phiHoaHongs = _context.PhiHoaHongs.Include(x => x.PhanCongSales).Include(x => x.PhanCongSales.NhanVienSales)
                    .Include(X => X.PhanCongSales.NhaDat.DuAn).Include(x => x.PhanCongSales.NhaDat.LoaiNhaDat).ToList();
            }

            var viewModel = new QuanLyPhiHoaHongViewModel
            {
                PhiHoaHongs = phiHoaHongs,
                DuAns = duAns,
                NhanVienSales = nhanVienSales
            };

            if (duAnId.HasValue)
            {
                viewModel.DuAnId = duAnId.Value;
                viewModel.PhiHoaHongs = viewModel.PhiHoaHongs.Where(x => x.PhanCongSales.NhaDat.DuAn.Id == duAnId.Value);
            }

            if (nhanVienSalesId.HasValue)
            {
                viewModel.NhanVienSalesId = nhanVienSalesId.Value;
                viewModel.PhiHoaHongs = viewModel.PhiHoaHongs.Where(x => x.PhanCongSales.NhanVienSalesId == nhanVienSalesId.Value);
            }

            return View("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PhiHoaHong phiHoaHong)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("New", phiHoaHong.PhanCongSales.Id);
            }
            if (phiHoaHong.Id == 0)
            {
                phiHoaHong.NgayTao = DateTime.Now;
                _context.PhiHoaHongs.Add(phiHoaHong);
                _context.PhanCongSales.SingleOrDefault(x => x.Id == phiHoaHong.PhanCongSalesId).DaTinhHoaHong = true;
                _context.SaveChanges();
                TempData["success"] = "Cập nhật thành công";
            }
            return RedirectToAction("Index", "QuanLyPhiHoaHong");
        }

        public ActionResult Export(int id)
        {
            try
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                var phiHoaHong = _context.PhiHoaHongs.Include(x => x.PhanCongSales).Include(x => x.PhanCongSales.NhanVienSales)
                    .Include(x => x.PhanCongSales.NhaDat).Include(x => x.PhanCongSales.NhanVienSales.PhongBan)
                    .Include(X => X.PhanCongSales.NhaDat.DuAn).Include(x => x.PhanCongSales.NhaDat.LoaiNhaDat).SingleOrDefault(x => x.Id == id);

                worksheet.get_Range("A1", "E1").Merge();
                worksheet.Cells[1, 2] = "Thống kê phí hoa hồng đã xuất cho nhân viên";

                worksheet.Cells[2, 2] = "Ngày xuất";
                worksheet.Cells[3, 2] = DateTime.Now.ToString("dd/MM/yyyy");

                worksheet.Cells[2, 3] = "Tổng phí hoa hồng";
                worksheet.Cells[3, 3] = phiHoaHong.TongChi;

                worksheet.Cells[4, 2] = "Nhân viên Sales";
                worksheet.Cells[4, 3] = phiHoaHong.PhanCongSales.NhanVienSales.HoTen;

                worksheet.Cells[5, 2] = "Phòng ban";
                worksheet.Cells[5, 3] = phiHoaHong.PhanCongSales.NhanVienSales.PhongBan.Ten;

                worksheet.Cells[6, 2] = "Số điện thoại";
                worksheet.Cells[6, 3] = phiHoaHong.PhanCongSales.NhanVienSales.SoDienThoai;

                worksheet.Cells[8, 2] = "Nhà đất";
                worksheet.Cells[9, 2] = phiHoaHong.PhanCongSales.NhaDat.Ten;

                worksheet.Cells[8, 3] = "Giá bán/Cho thuê";
                if (phiHoaHong.PhanCongSales.NhaDat.IsRent)
                {
                    worksheet.Cells[9, 3] = phiHoaHong.PhanCongSales.NhaDat.GiaThue;
                }
                else
                {
                    worksheet.Cells[9, 3] = phiHoaHong.PhanCongSales.NhaDat.GiaBan;
                }

                worksheet.Cells[8, 4] = "Phần trăm hoa hồng";
                worksheet.Cells[9, 4] = phiHoaHong.PhanCongSales.PhanTramHoaHong;

                worksheet.Cells[8, 5] = "Phí hoa hồng";
                worksheet.Cells[9, 5] = phiHoaHong.TongChi;

                worksheet.Cells[11, 2] = "Tổng";

                string tempPath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "_SalesCommission";
                workbook.SaveAs(tempPath, workbook.FileFormat);
                tempPath = workbook.FullName;
                workbook.Close();
                byte[] result = System.IO.File.ReadAllBytes(tempPath);
                System.IO.File.Delete(tempPath);

                this.Response.AddHeader("Content-Disposition", "SalesCommission.xlsx");
                this.Response.ContentType = "application/vnd.ms-excel";

                return File(result, "application/vnd.ms-excel");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
                throw ex;
            }
        }
    }
}