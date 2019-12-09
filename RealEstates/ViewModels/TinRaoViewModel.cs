using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.ViewModels
{
    public class TinRaoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Loại tin rao")]
        public int LoaiTinRao { get; set; }

        [Display(Name = "Giá tiền (VNĐ)")]
        public decimal GiaTien { get; set; }

        [Required]
        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }
        public TinhThanhPho TinhThanhPho { get; set; }

        [Required]
        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }
        public QuanHuyen QuanHuyen { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Display(Name = "Diện tích (m2)")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DienTich { get; set; }

        [Display(Name = "Hướng nhà")]
        public string HuongNha { get; set; }

        [Display(Name = "Số phòng")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int SoPhong { get; set; }

        [Display(Name = "Thông tin mô tả")]
        [AllowHtml]
        public string ThongTinMoTa { get; set; }

        [Display(Name = "Ảnh/ Video")]
        [AllowHtml]
        public string Media { get; set; }

        [Display(Name = "Từ khóa tìm kiếm")]
        public string TuKhoa { get; set; } // từ khóa vô hạn, thêm càng nhiều càng dễ kiếm

        [Display(Name = "Bản đồ")]
        public string BanDo { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [Display(Name = "Tiêu đề tin rao")]
        public string TieuDe { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Người gửi bài đăng")]
        public string AccountId { get; set; }
        public ApplicationUser Account { get; set; }

        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; } // chờ duyệt, hiển thị trên web, dừng đăng tin
        
        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<Option> LoaiTinRaoBDS { get; set; }

        public IEnumerable<Option> TrangThaiTinRao { get; set; }

        public TinRaoViewModel()
        {
            Id = 0;
            TrangThai = 1;
        }

        public TinRaoViewModel(TinRaoBDS tinRaoBDS)
        {
            Id = tinRaoBDS.Id;
            LoaiTinRao = tinRaoBDS.LoaiTinRao;
            TieuDe = tinRaoBDS.TieuDe;
            GiaTien = tinRaoBDS.GiaTien;
            TinhThanhPhoId = tinRaoBDS.TinhThanhPhoId;
            QuanHuyenId = tinRaoBDS.QuanHuyenId;
            DiaChi = tinRaoBDS.DiaChi;
            DienTich = tinRaoBDS.DienTich;
            HuongNha = tinRaoBDS.HuongNha;
            SoPhong = tinRaoBDS.SoPhong;
            ThongTinMoTa = tinRaoBDS.ThongTinMoTa;
            Media = tinRaoBDS.Media;
            TuKhoa = tinRaoBDS.TuKhoa;
            BanDo = tinRaoBDS.BanDo;
            AnhDaiDien = tinRaoBDS.AnhDaiDien;
            HoTen = tinRaoBDS.HoTen;
            SoDienThoai = tinRaoBDS.SoDienThoai;
            Email = tinRaoBDS.Email;

            AccountId = tinRaoBDS.AccountId;
            NgayTao = tinRaoBDS.NgayTao;
            TrangThai = tinRaoBDS.TrangThai;
        }
    }
}