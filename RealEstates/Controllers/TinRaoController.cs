using Microsoft.AspNet.Identity;
using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Controllers
{
    [AllowAnonymous]
    public class TinRaoController : Controller
    {
        public ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public TinRaoController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: TinRao
        public ActionResult Index()
        {
            var viewModel = new DanhSachTinRaoViewModel
            {
                TinRaoBDSs = _context.TinRaoBDSs.Include(x => x.LoaiNhaDat).ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao,
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
            };

            return View(viewModel);
        }

        public ActionResult Search(string keyWord, int? loaiNhaDatId, int? tinhThanhPhoId, int? quanHuyenId, int? dienTichId, int? khoangGiaId)
        {
            var viewModel = new DanhSachTinRaoViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.Include(x => x.TinhThanhPho).ToList(),
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
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
                viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.ThongTinMoTa.Contains(keyWord));
            }

            if (loaiNhaDatId.HasValue)
            {
                viewModel.LoaiNhaDatId = loaiNhaDatId.Value;
                viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.LoaiNhaDat.Id == loaiNhaDatId);
            }

            if (tinhThanhPhoId.HasValue)
            {
                viewModel.TinhThanhPhoId = tinhThanhPhoId.Value;
                viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.TinhThanhPho.Id == tinhThanhPhoId);
            }

            if (quanHuyenId.HasValue)
            {
                viewModel.QuanHuyenId = quanHuyenId.Value;
                viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.QuanHuyen.Id == quanHuyenId);
            }

            if (dienTichId.HasValue)
            {
                viewModel.DienTichId = dienTichId.Value;
                switch (dienTichId)
                {
                    case 1:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.DienTich < 20);
                        break;

                    case 2:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.DienTich >= 20 && x.DienTich <= 50);
                        break;

                    case 3:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.DienTich >= 50 && x.DienTich <= 100);
                        break;

                    case 4:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.DienTich > 100);
                        break;
                }
            }

            if (khoangGiaId.HasValue)
            {
                viewModel.KhoangGiaId = khoangGiaId.Value;
                switch (khoangGiaId)
                {
                    case 1:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.GiaTien < 2000000);
                        break;

                    case 2:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.GiaTien >= 2000000 || x.GiaTien <= 5000000);
                        break;

                    case 3:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.GiaTien > 5000000 && x.GiaTien < 500000000);
                        break;

                    case 4:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.GiaTien < 500000000 || x.GiaTien < 500000000);
                        break;

                    case 5:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => (x.GiaTien >= 500000000 && x.GiaTien < 2000000000) || (x.GiaTien >= 500000000 && x.GiaTien < 2000000000));
                        break;

                    case 6:
                        viewModel.TinRaoBDSs = viewModel.TinRaoBDSs.Where(x => x.GiaTien > 2000000000);
                        break;
                }
            }

            return View("Index", viewModel);
        }

        public ActionResult GetByLoaiTinRao(int? loaiTinRaoId)
        {
            var viewModel = new DanhSachTinRaoViewModel
            {
                TinRaoBDSs = _context.TinRaoBDSs.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen)
                    .Include(x => x.LoaiNhaDat)
                    .Where(x => x.LoaiTinRao == loaiTinRaoId).ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao,
                ThoiHanDangTins = SelectOptions.getThoiHanDangTin,
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
            };
            return View("Index", viewModel);
        }

        public ActionResult DanhSachTinRao()
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
            var userId = User.Identity.GetUserId();

            var viewModel = new DanhSachTinRaoViewModel
            {
                TinRaoBDSs = _context.TinRaoBDSs.Include(x => x.TinhThanhPho).Include(x => x.QuanHuyen)
                                .Include(x => x.LoaiNhaDat).Where(x => x.Account.Id == userId).ToList(),
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao,
                ThoiHanDangTins = SelectOptions.getThoiHanDangTin,
                DienTichs = SelectOptions.getDienTich,
                KhoangGias = SelectOptions.getKhoangGia
            };

            return View("DanhSachTinRao", viewModel);
        }

        [Authorize]
        public ActionResult New()
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

            var viewModel = new TinRaoViewModel
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao,
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                ThoiHanDangTins = SelectOptions.getThoiHanDangTin
            };

            return View("TinRaoForm", viewModel);
        }

        [Authorize]
        public ActionResult Save(TinRaoBDS tinRaoBDS)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("Index");
            }

            tinRaoBDS.ThongTinMoTa = HttpUtility.HtmlDecode(tinRaoBDS.ThongTinMoTa);
            tinRaoBDS.Media = HttpUtility.HtmlDecode(tinRaoBDS.Media);

            if (tinRaoBDS.Id == 0)
            {
                var userId = User.Identity.GetUserId();
                tinRaoBDS.AccountId = userId;
                tinRaoBDS.NgayTao = DateTime.Now;
                tinRaoBDS.TrangThai = 1;

                if (tinRaoBDS.ImageFile != null)
                {
                    string uploadPath = ConfigurationManager.AppSettings["AnhDaiDienTinRao"].ToString();
                    tinRaoBDS.AnhDaiDien = saveFile(tinRaoBDS.ImageFile, uploadPath);
                }
                else
                {
                    string uploadPath = ConfigurationManager.AppSettings["NoPhoto"].ToString();
                    tinRaoBDS.AnhDaiDien = uploadPath + "no-photo-available-300x225.png";
                }

                TempData["success"] = "Thêm mới thành công";
                _context.TinRaoBDSs.Add(tinRaoBDS);
            }
            else
            {
                var tinRaoInDB = _context.TinRaoBDSs.Single(x => x.Id == tinRaoBDS.Id);
                tinRaoInDB.TrangThai = tinRaoBDS.TrangThai;
                TempData["success"] = "Cập nhật thành công";
            }
            _context.SaveChanges();

            return RedirectToAction("New");
        }

        public ActionResult Details(int id)
        {
            var tinRao = _context.TinRaoBDSs.Include(x => x.TinhThanhPho)
                .Include(x => x.QuanHuyen).Include(x => x.LoaiNhaDat).SingleOrDefault(x => x.Id == id);

            if (tinRao == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TinRaoViewModel(tinRao)
            {
                TinhThanhPhos = _context.TinhThanhPhos.ToList(),
                QuanHuyens = _context.QuanHuyens.ToList(),
                TrangThaiTinRao = SelectOptions.getTrangThaiTinRao,
                LoaiTinRaoBDS = SelectOptions.getLoaiTinRaoBDS,
                LoaiNhaDats = _context.LoaiNhaDats.ToList(),
                ThoiHanDangTins = SelectOptions.getThoiHanDangTin
            };

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            var tinRao = _context.TinRaoBDSs.Include(x => x.TinhThanhPho)
                .Include(x => x.QuanHuyen).Include(x => x.LoaiNhaDat).SingleOrDefault(x => x.Id == id);

            if (tinRao == null)
            {
                return HttpNotFound();
            }

            return View(tinRao);
        }

        #region Helper

        public string saveFile(HttpPostedFileBase imageFile, string uploadPath)
        {
            string filePath = "";
            try
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imageFile.FileName);
                string fileExtension = Path.GetExtension(imageFile.FileName);
                string fileName = DateTime.Now.ToString("ddMMyyy") + "-" + fileNameWithoutExtension.Trim() + fileExtension;
                //Its Create complete path to store in server.
                filePath = uploadPath + fileName;
                //To copy and save file into server.
                imageFile.SaveAs(Server.MapPath(filePath));
            }
            catch (Exception ex)
            {
                ExceptionLogger.SendErrorToText(ex);
            }

            return filePath;
        }

        public void deleteFile(string filePath)
        {
            try
            {
                if (System.IO.File.Exists(Server.MapPath(filePath)))
                {
                    System.IO.File.Delete(Server.MapPath(filePath));
                }
            }
            catch (IOException ex)
            {
                ExceptionLogger.SendErrorToText(ex);
            }
        }

        #endregion Helper
    }
}