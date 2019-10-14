using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class QuanLyPhiHoaHongViewModel
    {
        public int DuAnId { get; set; }

        public int NhanVienSalesId { get; set; }

        public IEnumerable<PhiHoaHong> PhiHoaHongs { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<NhanVien> NhanVienSales { get; set; }

    }
}