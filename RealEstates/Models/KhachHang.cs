using RealEstates.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("KhachHang")] // chỉ có thể gọi là khách hàng, vì người đăng tin rao hoặc người đứng ra liên hệ không chắc là chủ nhà đất
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tài khoản")]
        public string AccountId { get; set; }
        public ApplicationUser Account { get; set; }

        public ICollection<TinRaoBDS> TinRaoBDSs { get; set; }
    }
}