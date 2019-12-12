using RealEstates.Areas.Admin.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    // tin rao cho mục đích sàn giao dịch bất động sản
    // khách hàng đăng ký tài khoản để tự đăng tin rao bán/cho thuê, tìm mua/tìm thuê
    // công ty không can thiệp, cũng như không phân công cho sales bán/cho thuê dùm
    // form tin rao không cần nhập lại thông tin khách hàng vì đã có thông tin
    // khách hàng lúc đăng nhập

    [Table("TinRaoBDS")]
    public class TinRaoBDS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Loại tin rao")]
        public int LoaiTinRao { get; set; }

        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }
        public LoaiNhaDat LoaiNhaDat { get; set; }

        [Display(Name = "Giá tiền (VNĐ)")]
        [Column(TypeName = "money")]
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

        [Display(Name = "Thời hạn đăng tin")]
        public int ThoiHanDangTin { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; } // chờ duyệt, hiển thị trên web, dừng đăng tin
    }
}