using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    [Table("DonViSanPham")]
    public class DonViSanPham
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá tiền")]
        public decimal GiaTien { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Trạng thái")] // 1: đã bán hoặc đã cho thuê, 0: chưa bán hoặc chưa cho thuê
        public bool TrangThai { get; set; }

        [Display(Name = "Dự án")]
        public virtual DuAn DuAn { get; set; }

        [Display(Name = "Loại đơn vị sản phẩm")]
        public virtual LoaiDonViSanPham LoaiDonVi { get; set; }

        [Display(Name = "Nhân viên Sales")]
        public virtual NhanVienSales NhanVienSales { get; set; }

        public virtual ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}
