using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    [Table("NhaDat")]
    public class NhaDat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "TieuDe")] // tên hiển thị trên web
        public string TieuDe { get; set; }

        // nhà đất đơn lẻ thì không có thông tin dự án
        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }
        public DuAn DuAn { get; set; }

        [Required]
        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }
        public LoaiNhaDat LoaiNhaDat { get; set; }

        [Display(Name = "Giá bán (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Giá thuê (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaThue { get; set; }

        [Required]
        [Display(Name = "Diện tích")]
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
        public string TuKhoa { get; set; }

        [Display(Name = "Bản đồ vị trí")] // bản đồ
        [AllowHtml]
        public string BanDo { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        #region THÔNG TIN RIÊNG CỦA NHÀ ĐẤT RIÊNG LẺ

        // nếu nhà đất thuộc dự án thì những thông tin này sẽ được tự động
        // phát sinh trên giao diện
        // không thuộc dự án thì nhân viên phải chọn từ combobox
        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }
        public TinhThanhPho TinhThanhPho { get; set; }

        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }
        public QuanHuyen QuanHuyen { get; set; }

        #endregion

        public ICollection<PhanCongSales> PhanCongSales { get; set; }

        public ICollection<TinRaoBDS> TinRaoBDSs { get; set; }
    }
}