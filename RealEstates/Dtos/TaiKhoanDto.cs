using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Dtos
{
    public class TaiKhoanDto
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Tài khoản")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Phân quyền")]
        public string Role { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
