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
        public int Id { get; set; }

        [Display(Name = "Tỉnh/TP")]
        public string Ten { get; set; }

        [Display(Name = "Tên viết tắt")]
        public string Code { get; set; }

        public ICollection<DuAn> DuAns { get; set; }

        public ICollection<QuanHuyen> QuanHuyens { get; set; }
    }
}