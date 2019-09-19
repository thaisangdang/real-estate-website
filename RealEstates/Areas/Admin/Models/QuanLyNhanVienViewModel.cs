using Microsoft.AspNet.Identity.EntityFramework;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class QuanLyNhanVienViewModel
    {
        [Display(Name = "Phân quyền")]
        public int RoleId { get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}