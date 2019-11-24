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
    // những nhà đất được phân công cho nhân viên sales sẽ tự động được đăng tin rao
    // nhà đất đã bán/cho thuê (trạng thái phân công hoàn thành) sẽ không load tin rao
    public class NhaDatViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên nhà đất")]
        public string Ten { get; set; }

        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }
        public DuAn DuAn { get; set; }

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
        [Display(Name = "Nhà đất cho thuê")]
        public bool IsRent { get; set; }

        [Display(Name = "Giá bán (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Giá thuê (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaThue { get; set; }

        [Required]
        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }
        public LoaiNhaDat LoaiNhaDat { get; set; }

        [Required]
        [Display(Name = "Diện tích (m2)")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DienTich { get; set; }

        [Display(Name = "Hướng nhà")]
        public string HuongNha { get; set; }

        [Display(Name = "Số phòng")]
        [Range(0, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int SoPhong { get; set; }

        [Display(Name = "Thông tin mô tả")]
        [AllowHtml]
        public string ThongTinMoTa { get; set; }

        [Display(Name = "Ảnh/ Video")]
        [AllowHtml]
        public string Media { get; set; }

        [Display(Name = "Từ khóa tìm kiếm")]
        public string TuKhoa { get; set; } // từ khóa vô hạn, thêm càng nhiều càng dễ kiếm

        [Display(Name = "Bản đồ")]
        public string BanDo { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }
        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }
        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }
        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Tạo mới nhà đất" : "Cập nhật thông tin nhà đất";
            }
        }

        public NhaDatViewModel()
        {
            Id = 0;
        }

        public NhaDatViewModel(NhaDat nhaDat)
        {
            Id = nhaDat.Id;
            DuAnId = nhaDat.DuAnId;
            IsRent = nhaDat.IsRent;
            LoaiNhaDatId = nhaDat.LoaiNhaDatId;
            TinhThanhPhoId = nhaDat.LoaiNhaDatId;
            QuanHuyenId = nhaDat.QuanHuyenId;
            DiaChi = nhaDat.DiaChi;            
            GiaBan = nhaDat.GiaBan;
            GiaThue = nhaDat.GiaThue;
            DienTich = nhaDat.DienTich;
            HuongNha = nhaDat.HuongNha;
            SoPhong = nhaDat.SoPhong;
            ThongTinMoTa = nhaDat.ThongTinMoTa;
            Media = nhaDat.Media;
            TuKhoa = nhaDat.TuKhoa;
            BanDo = nhaDat.BanDo;
            NgayTao = nhaDat.NgayTao;
        }

    }
}