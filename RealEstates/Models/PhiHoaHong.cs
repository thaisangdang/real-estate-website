using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    [Table("PhiHoaHong")]
    public class PhiHoaHong
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name = "Đơn vị dự án")]
        public string DonViDuAn { get; set; } // căn 33 tầng trệt, lô 5, phòng ....
                                              //public virtual DonViDuAn DonViDuAn { get; set; }
        [Display(Name = "Giá đơn vị dự án")]
        [Column(TypeName = "money")]
        public decimal GiaDonViDuAn { get; set; }

        public virtual NhanVienSales NhanVienSales { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Phí khác")]
        [Column(TypeName = "money")]
        public decimal PhiKhac { get; set; }

        [Display(Name = "Tổng tiền")]
        [Column(TypeName = "money")]
        public decimal TongChi { get; set; }

        [Display(Name = "Nhân viên")]
        public string NguoiChi { get; set; }

        [Display(Name = "Ngày chi")]
        public DateTime NgayChi { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

    }
}
