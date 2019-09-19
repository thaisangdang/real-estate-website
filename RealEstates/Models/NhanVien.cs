using Microsoft.AspNet.Identity.EntityFramework;
using RealEstates.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required]
        [Display(Name = "Phòng ban")]
        public int PhongBanId { get; set; }

        public PhongBan PhongBan { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        [Range(1, 3)]
        public int TrangThai { get; set; }

        [Required]
        [Display(Name = "Tài khoản")]
        public string AccountId { get; set; }

        public ApplicationUser Account { get; set; }

        public ICollection<DuAn> DuAns { get; set; }

        public ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}
