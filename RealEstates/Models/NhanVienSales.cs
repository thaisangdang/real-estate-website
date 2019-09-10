using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    [Table("NhanVienSales")]
    public class NhanVienSales
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(13)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        public string AccountId { get; set; }

        public virtual ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}
