using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class NhanVienViewModel
    {
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

        [Display(Name = "Phòng ban")]
        public int PhongBanId { get; set; }

        [Display(Name = "Tài khoản")]
        public string AccountId { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        [Range(1, 3)]
        public int TrangThai { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Thêm thông tin nhân viên" : "Cập nhật thông tin nhân viên";
            }
        }

        public IEnumerable<PhongBan> PhongBans { get; set; }

        // list tài khoản trong hệ thống
        public List<ApplicationUser> Accounts { get; set; }

        public IEnumerable<Option> TrangThaiNhanVien { get; set; }

        public NhanVienViewModel()
        {
            Id = 0;
            TrangThai = 1;
        }

        public NhanVienViewModel(NhanVien nhanVien)
        {
            Id = nhanVien.Id;
            HoTen = nhanVien.HoTen;
            Email = nhanVien.Email;
            SoDienThoai = nhanVien.SoDienThoai;
            PhongBanId = nhanVien.PhongBanId;
            AccountId = nhanVien.AccountId;
            TrangThai = nhanVien.TrangThai;
        }

    }
}