using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    [Table("NhaDat")]
    public class NhaDat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nhà đất")]
        public string Ten { get; set; }

        [Required]
        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }
        public DuAn DuAn { get; set; }

        [Required]
        [Display(Name = "Nhà đất cho thuê")]
        public bool IsRent { get; set; }

        [Required]
        [Display(Name = "Loại nhà đất")] // load loại nhà đất theo thuộc tính Isrent ở trên 
        public int LoaiNhaDatId { get; set; }
        public LoaiNhaDat LoaiNhaDat { get; set; }

        [Display(Name = "Giá bán (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Giá thuê (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaThue { get; set; }

        [Required]
        [Display(Name = "Diện tích")]
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
        public string TuKhoa { get; set; }

        [Display(Name = "Bản đồ")]
        [AllowHtml]
        public string BanDo { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public ICollection<PhanCongSales> PhanCongSales { get; set; }

    }
}