using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("PhongBan")]
    public class PhongBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        public ICollection<NhanVien> NhanViens { get; set; }
    }
}