using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.ViewModels
{
    public class DuAnViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên dự án")]
        public string TenDuAn { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Giá từ")]
        public decimal GiaTu { get; set; }

        [Required]
        [Display(Name = "Chủ đầu tư")]
        public string ChuDauTu { get; set; }

        [Required]
        [Display(Name = "Tổng diện tích")]
        public string TongDienTich { get; set; }

        [Required]
        [Display(Name = "Tiến độ dự án")]
        public string TienDoDuAn { get; set; }

        [Required]
        [Display(Name = "Loại hình phát triển")]
        public int LoaiDuAnId { get; set; }

        [Required]
        [Display(Name = "Quy mô dự án")]
        public string QuyMoDuAn { get; set; }

        [Required]
        [Display(Name = "Giới thiệu dự án")]
        [AllowHtml]
        public string GioiThieuDuAn { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Vị trí")]
        public string ViTri { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Hạ tầng")]
        public string HaTang { get; set; }

        [Required]
        [Display(Name = "Thiết kế")]
        [AllowHtml]
        public string ThietKe { get; set; }

        [Required]
        [Display(Name = "Mặt bằng")]
        [AllowHtml]
        public string MatBang { get; set; }

        [Required]
        [Display(Name = "Video/Ảnh")]
        [AllowHtml]
        public string Media { get; set; }

        [Required]
        [Display(Name = "Hỗ trợ tài chính")]
        [AllowHtml]
        public string HoTroTaiChinh { get; set; }

        [Required]
        [Display(Name = "Tỉnh/Thành phố")]
        public int TinhThanhPhoId { get; set; }

        [Required(ErrorMessage = "Số đơn vị phải >= 0")]
        [Display(Name = "Số đơn vị dự án")]
        [Range(0, int.MaxValue)]
        public int SoDonViDuAn { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [AllowHtml]
        public string AnhDaiDien { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Ngày đăng")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayDang { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Tạo mới dự án" : "Chỉnh sửa dự án";
            }
        }

        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public DuAnViewModel()
        {
            Id = 0;
        }

        public DuAnViewModel(DuAn duAn)
        {
            Id = duAn.Id;
            TenDuAn = duAn.TenDuAn;
            DiaChi = duAn.DiaChi;
            GiaTu = duAn.GiaTu;
            ChuDauTu = duAn.ChuDauTu;
            TongDienTich = duAn.TongDienTich;
            TienDoDuAn = duAn.TienDoDuAn;
            QuyMoDuAn = duAn.QuyMoDuAn;
            GioiThieuDuAn = duAn.GioiThieuDuAn;
            ViTri = duAn.ViTri;
            HaTang = duAn.HaTang;
            ThietKe = duAn.ThietKe;
            MatBang = duAn.MatBang;
            Media = duAn.Media;
            HoTroTaiChinh = duAn.HoTroTaiChinh;
            SoDonViDuAn = duAn.SoDonViDuAn;
            AnhDaiDien = duAn.AnhDaiDien;
            NgayDang = duAn.NgayDang;
        }

    }
}