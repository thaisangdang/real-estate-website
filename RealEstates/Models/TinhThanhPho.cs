using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("TinhThanhPho")]
    public class TinhThanhPho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tỉnh/TP")]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name = "Tỉnh/TP")]
        public string Ten { get; set; }

        public ICollection<DuAn> DuAns { get; set; }
    }
}