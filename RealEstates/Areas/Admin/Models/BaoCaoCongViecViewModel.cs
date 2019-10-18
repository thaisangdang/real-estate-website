using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class BaoCaoCongViecViewModel
    {
        public PhanCongSales PhanCongSales { get; set; }

        public IEnumerable<Option> TrangThaiCongViec { get; set; }
    }
}