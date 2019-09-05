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

        public virtual DonViDuAn DonViDuAn { get; set; }

        public virtual NhanVienSales NhanVienSales { get; set; }

        public DateTime NgayChi { get; set; }

        [Column(TypeName = "money")]
        public decimal SoTien { get; set; }
    }
}
