using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class UserProfileViewModel
    {
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

    }
}