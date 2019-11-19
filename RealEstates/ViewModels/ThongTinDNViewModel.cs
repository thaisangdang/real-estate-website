using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.ViewModels
{
    public class ThongTinDNViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên doanh nghiệp")]
        public string Ten { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [AllowHtml]
        [Display(Name = "Giới thiệu")]
        public string GioiThieu { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Tạo mới thông tin doanh nghiệp" : "Chỉnh sửa thông tin doanh nghiệp";
            }
        }

        public ThongTinDNViewModel()
        {
            Id = 0;
        }

        public ThongTinDNViewModel(DoanhNghiepBDS doanhNghiepBDS)
        {
            Id = doanhNghiepBDS.Id;
            Ten = doanhNghiepBDS.Ten;
            DiaChi = doanhNghiepBDS.DiaChi;
            SoDienThoai = doanhNghiepBDS.SoDienThoai;
            Email = doanhNghiepBDS.Email;
            Website = doanhNghiepBDS.Website;
            GioiThieu = doanhNghiepBDS.GioiThieu;
            AnhDaiDien = doanhNghiepBDS.AnhDaiDien;
        }
    }
}