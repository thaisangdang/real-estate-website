using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class QuanLyLoaiDuAnViewModel
    {
        public IEnumerable<DuAn> DuAns { get; set; }
        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }
    }
}