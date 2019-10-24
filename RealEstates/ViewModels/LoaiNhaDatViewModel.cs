using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.ViewModels
{
    public class LoaiNhaDatViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Loại nhà đất")]
        public string TenLoai { get; set; }

        // cho thuê hay bán
        [Display(Name = "Nhà đất cho thuê")] // dùng checkbox
        public bool IsRent { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "Tạo mới loại nhà đất" : "Cập nhật thông tin loại nhà đất";
            }
        }

        public LoaiNhaDatViewModel()
        {
            Id = 0;
        }

        public LoaiNhaDatViewModel(LoaiNhaDat loaiNhaDat)
        {
            Id = loaiNhaDat.Id;
            TenLoai = loaiNhaDat.TenLoai;
            IsRent = loaiNhaDat.IsRent;
        }

    }
}