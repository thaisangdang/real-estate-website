﻿using RealEstates.Areas.Admin.Models;
using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.ViewModels
{
    public class TinRaoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Loại tin rao")]
        public int LoaiTinRao { get; set; }

        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }

        public LoaiNhaDat LoaiNhaDat { get; set; }

        [Display(Name = "Giá tiền (VNĐ)")]
        public decimal GiaTien { get; set; }

        [Required]
        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }

        public TinhThanhPho TinhThanhPho { get; set; }

        [Required]
        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }

        public QuanHuyen QuanHuyen { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Display(Name = "Diện tích (m2)")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DienTich { get; set; }

        [Display(Name = "Thông tin mô tả")]
        [AllowHtml]
        public string ThongTinMoTa { get; set; }

        [Display(Name = "Ảnh/ Video")]
        [AllowHtml]
        public string Media { get; set; }

        [Display(Name = "Từ khóa tìm kiếm")]
        public string TuKhoa { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [Display(Name = "Tiêu đề tin rao")]
        public string TieuDe { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Người gửi bài đăng")]
        public string AccountId { get; set; }

        public ApplicationUser Account { get; set; }

        [Display(Name = "Người đại diện liên hệ")]
        public string HoTen { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Thời hạn đăng tin")]
        public int ThoiHanDangTin { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<Option> LoaiTinRaoBDS { get; set; }

        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }

        public IEnumerable<Option> TrangThaiTinRao { get; set; }

        public IEnumerable<Option> ThoiHanDangTins { get; set; }

        public TinRaoViewModel()
        {
            Id = 0;
            TrangThai = 1;
        }

        public TinRaoViewModel(TinRaoBDS tinRaoBDS)
        {
            Id = tinRaoBDS.Id;
            LoaiTinRao = tinRaoBDS.LoaiTinRao;
            LoaiNhaDatId = tinRaoBDS.LoaiNhaDatId;
            TieuDe = tinRaoBDS.TieuDe;
            GiaTien = tinRaoBDS.GiaTien;
            TinhThanhPhoId = tinRaoBDS.TinhThanhPhoId;
            QuanHuyenId = tinRaoBDS.QuanHuyenId;
            DiaChi = tinRaoBDS.DiaChi;
            DienTich = tinRaoBDS.DienTich;
            ThongTinMoTa = tinRaoBDS.ThongTinMoTa;
            Media = tinRaoBDS.Media;
            TuKhoa = tinRaoBDS.TuKhoa;
            AnhDaiDien = tinRaoBDS.AnhDaiDien;
            HoTen = tinRaoBDS.HoTen;
            SoDienThoai = tinRaoBDS.SoDienThoai;
            Email = tinRaoBDS.Email;
            ThoiHanDangTin = tinRaoBDS.ThoiHanDangTin;
            AccountId = tinRaoBDS.AccountId;
            NgayTao = tinRaoBDS.NgayTao;
            TrangThai = tinRaoBDS.TrangThai;
        }
    }
}