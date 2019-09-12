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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Tài khoản")]
        public string AccountId { get; set; }

        [Required]
        public ApplicationUser Account { get; set; }

        public ICollection<DuAn> DuAns { get; set; }

        public ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}
