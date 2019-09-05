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
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Tên dự án")]
        public string TenDuAn { get; set; }

        [StringLength(500)]
        [Display(Name = "Chủ đầu tư")]
        public string ChuDauTu { get; set; }

        [StringLength(500)]
        [Display(Name = "Đơn vị thiết kế")]
        public string DonViThietKe { get; set; }

        [StringLength(500)]
        [Display(Name = "Đơn vị thi công")]
        public string DonViThiCong { get; set; }

        [StringLength(500)]
        [Display(Name = "Diện tích")]
        public string DienTich { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá từ")]
        public decimal GiaTu { get; set; }

        [StringLength(50)]
        [Display(Name = "Hiện trạng")]
        public string HienTrang { get; set; }

        [StringLength(50)]
        [Display(Name = "Khởi công")]
        public string KhoiCong { get; set; }

        [StringLength(50)]
        [Display(Name = "Hoàn thành")]
        public string HoanThanh { get; set; }

        [Display(Name = "Diện tích đất")]
        public double DienTichDat { get; set; }

        [Display(Name = "Diện tích sàn")]
        public double DienTichSan { get; set; }

        [Display(Name = "Số tầng")]
        [DisplayFormat(DataFormatString = "{0:N0} tầng")]
        public int SoTang { get; set; }

        [Display(Name = "Tổng vốn đầu tư")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal TongVonDauTu { get; set; }

        [Display(Name = "Thông tin dự án")]
        [AllowHtml]
        public string ThongTinDuAn { get; set; }

        [Display(Name = "Video/Ảnh")]
        [AllowHtml]
        public string Media { get; set; }

        [AllowHtml]
        [Display(Name = "Vị trí")]
        public string ViTri { get; set; }

        [Display(Name = "Địa phương")]
        public virtual TinhThanhPho TinhThanhPho { get; set; }

        [StringLength(500)]
        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [StringLength(500)]

        [Display(Name = "Loại dự án")]
        public virtual LoaiDuAn LoaiDuAn { get; set; }

        [Display(Name = "Ngày đăng")]
        public DateTime? NgayDang { get; set; }

    }
}