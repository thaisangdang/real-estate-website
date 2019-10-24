using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("TinRaoBDS")]
    public class TinRaoBDS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nhà đất")]
        public int NhaDatId { get; set; }
        public NhaDat NhaDat { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

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