using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class PhanCongSalesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Dự Án")]
        public int DuAnId { get; set; }
        public DuAn DuAn { get; set; }

        [Display(Name = "Nhà đất thuộc dự án")]
        public int NhaDatId { get; set; }
        public NhaDat NhaDat { get; set; }

        [Display(Name = "Nhà đất cho thuê")]
        public bool IsRent { get; set; }

        [Display(Name = "Giá bán (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Giá thuê (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaThue { get; set; }

        [Display(Name = "Phần trăm hoa hồng (%)")]
        [DisplayFormat(DataFormatString = "{0:N0}%")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Nhân viên sales")]
        public int NhanVienSalesId { get; set; }

        public NhanVien NhanVienSales { get; set; }

        [Display(Name = "Trạng thái")] // hoàn thành hay chưa
        public int TrangThai { get; set; }

        [Display(Name = "Tính phí hoa hồng")] // hoàn thành hay chưa
        public bool DaTinhHoaHong { get; set; }

        [Display(Name = "Người tạo")]
        public string NguoTao { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm tt}")]
        public DateTime? NgayTao { get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<NhaDat> NhaDats { get; set; }

        public IEnumerable<Option> TrangThaiPhanCong { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Phân công công việc cho nhân viên sales" : "Cập nhật trạng thái phân công";
            }
        }

        public PhanCongSalesViewModel()
        {
            Id = 0;
            TrangThai = 1; // mặc định chưa hoàn thành
        }

        public PhanCongSalesViewModel(PhanCongSales phanCongSales)
        {
            Id = phanCongSales.Id;
            DuAnId = phanCongSales.DuAnId;
            NhaDatId = phanCongSales.NhaDatId;
            PhanTramHoaHong = phanCongSales.PhanTramHoaHong;
            IsRent = phanCongSales.NhaDat.LoaiNhaDat.IsRent;
            GiaThue = phanCongSales.NhaDat.GiaThue;
            NhanVienSalesId = phanCongSales.NhanVienSalesId;
            TrangThai = phanCongSales.TrangThai;
            DaTinhHoaHong = phanCongSales.DaTinhHoaHong;
            NguoTao = phanCongSales.NguoTao;
            NgayTao = phanCongSales.NgayTao;
        }
    }
}
