using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    [Table("TinRaoBDS")]
    public class TinRaoBDS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nhà đất cho thuê")]
        public bool IsRent { get; set; }

        [Display(Name = "Giá bán (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Giá thuê (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaThue { get; set; }

        [Required]
        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }
        public LoaiNhaDat LoaiNhaDat { get; set; }

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
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [Display(Name = "Tiêu đề tin rao")]
        public string TieuDe { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Ngày bắt đầu đăng tin rao")]
        public DateTime NgayBatDauDangTinRao { get; set; }

        [Display(Name = "Ngày Kết thúc đăng tin rao")]
        public DateTime NgayKetThucDangTinRao { get; set; }

        [Display(Name = "Người gửi bài đăng")]
        public int KhachHangId { get; set; }
        public KhachHang KhachHang { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; } // chờ duyệt, hiển thị trên web, dừng đăng tin
    }
}