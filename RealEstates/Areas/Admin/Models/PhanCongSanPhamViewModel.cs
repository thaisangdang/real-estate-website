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
    public class PhanCongSanPhamViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }

        public DuAn DuAn { get; set; }

        [Display(Name = "Sản phẩm cần bán hoặc cho thuê")]
        public string SanPham { get; set; }

        [Display(Name = "Giá bán sản phẩm (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaBanSanPham { get; set; }

        [Display(Name = "Phần trăm hoa hồng (%)")]
        [DisplayFormat(DataFormatString = "{0:N0}%")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Sản phẩm cho thuê")]
        public bool IsRent { get; set; }

        [Display(Name = "Giá thuê tháng đầu (VNĐ)")]
        [Column(TypeName = "money")]
        public decimal GiaThueThangDau { get; set; }

        [Required]
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
        public DateTime NgayTao { get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<Option> TrangThaiPhanCong { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Phân công sản phẩm cho nhân viên sales" : "Chỉnh sửa thông tin phân công";
            }
        }

        public PhanCongSanPhamViewModel()
        {
            Id = 0;
            TrangThai = 1; // mặc định chưa hoàn thành
        }

        public PhanCongSanPhamViewModel(PhanCongSanPham phanCongSanPham)
        {
            Id = phanCongSanPham.Id;
            DuAnId = phanCongSanPham.DuAnId;
            SanPham = phanCongSanPham.SanPham;
            GiaBanSanPham = phanCongSanPham.GiaBanSanPham;
            PhanTramHoaHong = phanCongSanPham.PhanTramHoaHong;
            IsRent = phanCongSanPham.IsRent;
            GiaThueThangDau = phanCongSanPham.GiaThueThangDau;
            NhanVienSalesId = phanCongSanPham.NhanVienSalesId;
            TrangThai = phanCongSanPham.TrangThai;
            DaTinhHoaHong = phanCongSanPham.DaTinhHoaHong;
            NguoTao = phanCongSanPham.NguoTao;
            NgayTao = phanCongSanPham.NgayTao;
        }
    }
}
