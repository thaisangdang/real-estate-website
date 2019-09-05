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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name = "Tỉnh/TP")]
        public string Ten { get; set; }

        public virtual ICollection<DuAn> DuAns { get; set; }
    }
}