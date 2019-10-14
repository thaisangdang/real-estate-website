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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Phân công sản phẩm")]
        public int PhanCongSanPhamId { get; set; }

        public PhanCongSanPham PhanCongSanPham { get; set; }

        [Display(Name = "Tổng tiền")]
        [Column(TypeName = "money")]
        public decimal TongChi { get; set; }

        [Display(Name = "Người tạo")]
        public int NguoiTaoId { get; set; }

        [Display(Name = "Người tạo")]
        public NhanVien NguoiTao { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

    }
}
