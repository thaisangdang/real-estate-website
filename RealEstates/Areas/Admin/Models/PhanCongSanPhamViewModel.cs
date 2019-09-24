using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class PhanCongSanPhamViewModel
    {
        public DuAn DuAn { get; set; }

        public PhanCongSanPham PhanCongSanPham { get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set; } // ds nhân viên có tài khoản phân quyền là sales chưa được phân công cho dự án hiện tại

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<PhanCongSanPham> PhanCongSanPhams { get; set; }
    }
}
