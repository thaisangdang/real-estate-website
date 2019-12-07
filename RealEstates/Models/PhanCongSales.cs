﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    [Table("PhanCongSales")]
    public class PhanCongSales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // tại sao chỉ phân công cho nhân viên sales nhà đất thuộc dự án??
        // vì nhà đất thuộc dự án có giá trị lớn, số lượng nhiều, pháp lý rõ ràng và lâu dài, đủ cơ sở trả tiền hoa hồng cho sales
        // nhà đất đơn lẻ thường có giá trị thấp hơn, tính ra hoa hồng không nhiều mà chi phí bỏ ra cho các công việc liên quan lớn, không đủ trả lương cho sales
        // cho khách hàng đăng tin rao rồi thu phí tin rao thôi, tin rao không phân cho sales đi bán
        [Display(Name = "Dự Án")]
        public int DuAnId { get; set; }
        public DuAn DuAn { get; set; }

        [Display(Name = "Nhà đất")]
        public int NhaDatId { get; set; } // nhà đất thuộc dự án, hoặc nhà đất đơn lẻ
        public NhaDat NhaDat { get; set; }

        [Required]
        [Display(Name = "Nhân viên sales")]
        public int NhanVienSalesId { get; set; }
        public NhanVien NhanVienSales { get; set; }

        [Display(Name = "Trạng thái")] // hoàn thành hay chưa
        public int TrangThai { get; set; }

        [Display(Name = "Phần trăm hoa hồng")]
        [Range(0, double.MaxValue)]
        public double PhanTramHoaHong { get; set; }

        [Display(Name = "Tính phí hoa hồng")] // đã tính hoa hồng hay chưa
        public bool DaTinhHoaHong { get; set; }

        [Display(Name = "Người tạo")]
        public string NguoTao { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayTao { get; set; }

        public ICollection<PhiHoaHong> PhiHoaHongs { get; set; }

    }
}