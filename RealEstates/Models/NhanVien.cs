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

        [Required]
        [Display(Name = "Phân quyền")]
        public string PhanQuyen { get; set; }

        [Required]
        public string Account { get; set; } // email of ApplicationUser

        public ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}
