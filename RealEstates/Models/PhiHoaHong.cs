using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Tính phí xong phải trừ số lượng trong dự án, dự án số đơn vị = 0 thì không hiện trên web
 */

namespace RealEstates.Models
{
    [Table("PhiHoaHong")]
    public class PhiHoaHong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Đơn vị dự án")]
        public string DonViDuAn { get; set; } // bán gì, trong dự án nào

        [Display(Name = "Giá đơn vị dự án")]
        [Column(TypeName = "money")]
        public decimal GiaDonViDuAn { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Phí khác")]
        [Column(TypeName = "money")]
        public decimal PhiKhac { get; set; }

        [Display(Name = "Tổng tiền")]
        [Column(TypeName = "money")]
        public decimal TongChi { get; set; }

        [Display(Name = "Nhân viên sales")]
        public int NhanVienId { get; set; }

        public NhanVien NhanVienSales { get; set; }

        [Display(Name = "Nhân viên")]
        public string NguoiChi { get; set; } // Lưu email account

        [Display(Name = "Ngày chi")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayChi { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

    }
}
