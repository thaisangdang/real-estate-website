using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }
    }
}