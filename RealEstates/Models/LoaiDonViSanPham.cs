﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Models
{
    [Table("LoaiDonViSanPham")]
    public class LoaiDonViSanPham
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        public virtual ICollection<DonViSanPham> DonViSanPhams { get; set; }
    }
}