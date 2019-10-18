using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("LoaiNhaDat")]
    public class LoaiNhaDat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Loại nhà đất")]
        public string TenLoai { get; set; }

        // cho thuê hay bán
        [Display(Name = "Nhà đất cho thuê")] // dùng checkbox
        public bool IsRent { get; set; }

        public ICollection<NhaDat> NhaDats { get; set; }
    }
}