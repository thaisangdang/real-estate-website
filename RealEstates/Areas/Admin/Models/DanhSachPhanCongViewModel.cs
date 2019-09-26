using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class DanhSachPhanCongViewModel
    {
        public int TrangThai { get; set; }

        public int DuAnId { get; set; }

        public int NhanVienSalesId { get; set; }

        public IEnumerable<PhanCongSanPhamViewModel> PhanCongSanPhams { get; set; }
        public IEnumerable<Option> TrangThaiPhanCong { get; set; }
        public IEnumerable<DuAn> DuAns { get; set; }
        public IEnumerable<NhanVien> NhanVienSales { get; set; }

        public string GetLableColor(int trangThai)
        {
            string color = "";
            switch (trangThai)
            {
                case 1:
                    color = "bg-danger";
                    break;
                case 2:
                    color = "bg-success";
                    break;
                case 3:
                    color = "bg-secondary";
                    break;
                default:
                    break;
            }
            return color;
        }
    }
}