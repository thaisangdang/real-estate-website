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
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại Dự Án")]
        public string TenLoai { get; set; }

        [Display(Name = "Bán hoặc cho thuê")]
        public bool ChoThue { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        public virtual ICollection<DuAn> DuAns { get; set; }

    }
}
