using Microsoft.AspNet.Identity.EntityFramework;
using RealEstates.Helper;
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

        public IEnumerable<Option> TrangThaiNhanVien { get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }

        public string GetLableColor(int trangThai)
        {
            string color = "";
            switch (trangThai)
            {
                case 1: 
                    color = "bg-success";
                    break;
                case 2:
                case 3:
                    color = "bg-secondary";
                    break;
                default:
                    break;
            }
            return color;
        }
    }
}