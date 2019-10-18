using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    [Table("DuAn")]
    public class DuAn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phải nhập tên dự án")]
        [Display(Name = "Tên dự án")]
        public string TenDuAn { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Giá từ (VNĐ)")]
        public decimal GiaTu { get; set; }

        [Required]
        [Display(Name = "Chủ đầu tư")]
        public string ChuDauTu { get; set; }

        [Required]
        [Display(Name = "Tổng diện tích (m2)")]
        [Range(0, int.MaxValue)]
        public int TongDienTich { get; set; }

        [Required]
        [Display(Name = "Tiến độ dự án")]
        public string TienDoDuAn { get; set; }

        [Required]
        [Display(Name = "Loại hình phát triển")]
        public int LoaiDuAnId { get; set; }

        [Display(Name = "Loại hình phát triển")]
        public LoaiDuAn LoaiDuAn { get; set; }

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
        [Display(Name = "Tỉnh/Thành phố")]
        public TinhThanhPho TinhThanhPho { get; set; }

        [Required]
        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }
        [Display(Name = "Quận huyện")]
        public QuanHuyen QuanHuyen { get; set; }

        [Required(ErrorMessage = "Số sản phẩm phải >= 0")]
        [Display(Name = "Số sản phẩm")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        //[DisplayFormat(DataFormatString = "{0:N0} sản phẩm")]
        public int SoSanPham { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [Display(Name = "Người đăng")]
        public int NguoiDangId { get; set; }

        [Display(Name = "Người đăng")]
        public NhanVien NguoiDang { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        [Range(1, 4)]
        public int TrangThai { get; set; }

        [Display(Name = "Ngày đăng")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm tt}")]
        public DateTime? NgayDang { get; set; }

        public ICollection<PhanCongSales> PhanCongSales { get; set; }

        public ICollection<NhaDat> NhaDats { get; set; }
    }
}