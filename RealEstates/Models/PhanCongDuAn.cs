﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("PhanCongDuAn")]
    public class PhanCongDuAn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }

        public DuAn DuAn { get; set; }

        [Display(Name = "Đơn vị dự án")]
        public string DonViDuAn { get; set; } // bán gì, trong dự án nào

        [Display(Name = "Giá đơn vị dự án")]
        [Column(TypeName = "money")]
        public decimal GiaDonViDuAn { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        [Range(0, 100)]
        public double PhanTramHoaHong { get; set; }

        [Required]
        [Display(Name = "Nhân viên sales")]
        public int NhanVienSalesId { get; set; }

        public NhanVien NhanVienSales { get; set; }

        [Display(Name = "Trạng thái")] // hoàn thành hay chưa
        public bool TrangThai { get; set; }

        [Display(Name = "Người tạo")]
        public string NguoTao { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayTao { get; set; }

        public ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}