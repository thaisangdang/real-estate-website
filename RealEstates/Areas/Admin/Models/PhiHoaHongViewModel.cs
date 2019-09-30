using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class PhiHoaHongViewModel
    {
        // data of phihoahong
        public int Id { get; set; }

        [Required]
        [Display(Name = "Phân công sản phẩm")]
        public int PhanCongSanPhamId { get; set; }

        [Display(Name = "Tổng tiền (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal TongChi { get; set; }

        [Display(Name = "Người tạo")]
        public int NguoiTaoId { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        // Details for display
        [Display(Name = "Nhân viên sales")]
        public string NhanVienSales { get; set; } // họ tên
        
        [Display(Name = "Dự án")]
        public string TenDuAn { get; set; }
        
        [Display(Name = "Sản phẩm")]
        public string SanPham { get; set; }

        public bool IsRent { get; set; }

        [Display(Name = "Giá thuê tháng đầu (VNĐ)")]
        public decimal GiaThueThangDau { get; set; }

        [Display(Name = "Giá bán sản phẩm (VNĐ)")]
        public decimal GiaBanSanPham { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        public double PhanTramHoaHong { get; set; }

        public PhiHoaHongViewModel(PhiHoaHong phiHoaHong)
        {
            Id = 0;
            PhanCongSanPhamId = phiHoaHong.PhanCongSanPhamId;
            NguoiTaoId = phiHoaHong.NguoiTaoId;
            TongChi = phiHoaHong.TongChi;
        }
    }
}