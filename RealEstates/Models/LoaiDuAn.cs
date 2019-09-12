using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("LoaiDuAn")]
    public class LoaiDuAn
    {
        [Key]
        [Display(Name = "Loại dự án")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Loại dự án")]
        public string TenLoai { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        public ICollection<DuAn> DuAns { get; set; }

    }
}
