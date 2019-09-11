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

        [Required]
        [StringLength(50)]
        [Display(Name = "Loại dự án")]
        public string TenLoai { get; set; }

        [Display(Name = "Dự án")]
        public bool ChoThue { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        public virtual ICollection<DuAn> DuAns { get; set; }

    }
}
