using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("PhanCongSanPham")]
    public class PhanCongSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }

        public DuAn DuAn { get; set; }

        [Display(Name = "Sản phẩm")]
        public string SanPham { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Column(TypeName = "money")]
        public decimal GiaSanPham { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        [DisplayFormat(DataFormatString = "{0:N0}%")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Sản phẩm cho thuê")] // dùng checkbox
        public bool IsRent { get; set; }

        [Display(Name = "Giá thuê tháng đầu")]
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayTao { get; set; }

        public ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}