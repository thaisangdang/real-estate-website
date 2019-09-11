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

        [Required]
        [StringLength(500)]
        [Display(Name = "Tên dự án")]
        public string TenDuAn { get; set; }

        [Required]
        [Display(Name = "Loại dự án")]
        public virtual LoaiDuAn LoaiDuAn { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Chủ đầu tư")]
        public string ChuDauTu { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Đơn vị thiết kế")]
        public string DonViThietKe { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Đơn vị thi công")]
        public string DonViThiCong { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Diện tích")]
        public string DienTich { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Giá từ")]
        public decimal GiaTu { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hiện trạng")]
        public string HienTrang { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Khởi công")]
        public string KhoiCong { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hoàn thành")]
        public string HoanThanh { get; set; }

        [Required]
        [Display(Name = "Diện tích đất")]
        public double DienTichDat { get; set; }

        [Required]
        [Display(Name = "Diện tích sàn")]
        public double DienTichSan { get; set; }

        [Required]
        [Display(Name = "Số tầng")]
        [DisplayFormat(DataFormatString = "{0:N0} tầng")]
        public int SoTang { get; set; }

        [Required]
        [Display(Name = "Tổng vốn đầu tư")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal TongVonDauTu { get; set; }

        [Required]
        [Display(Name = "Thông tin dự án")]
        [AllowHtml]
        public string ThongTinDuAn { get; set; }

        [Required]
        [Display(Name = "Video/Ảnh")]
        [AllowHtml]
        public string Media { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Vị trí")]
        public string ViTri { get; set; }

        [Required]
        [Display(Name = "Tỉnh/Thành phố")]
        public virtual TinhThanhPho TinhThanhPho { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        // để biết dự án bán hết chưa, còn bao nhiêu
        [Display(Name = "Số đơn vị dự án")]
        [Range(0, int.MaxValue)]
        public int SoDonViDuAn { get; set; }

        [Display(Name = "Ngày đăng")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayDang { get; set; }

    }
}