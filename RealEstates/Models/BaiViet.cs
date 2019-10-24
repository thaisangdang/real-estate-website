using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Loại bài viết")]
        public int LoaiBaiVietId { get; set; }
        public LoaiBaiViet LoaiBaiViet { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [Display(Name = "Người tạo")]
        public int NguoiTaoId { get; set; }
        public NhanVien NguoiTao { get; set; }

        [Display(Name = "Ngày bắt đầu đăng")]
        public DateTime NgayBatDauDang { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [Display(Name = "Lượt xem")]
        public int LuotXem { get; set; }
    }
}
