using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class PhanCongDuAnViewModel
    {
        public DuAn DuAn { get; set; }

        public PhanCongDuAn PhanCongDuAn { get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<PhanCongDuAn> PhanCongDuAns { get; set; }

    }
}