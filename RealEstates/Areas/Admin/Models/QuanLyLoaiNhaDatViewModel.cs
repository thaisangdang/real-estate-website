using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class QuanLyLoaiNhaDatViewModel
    {
        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }
    }
}