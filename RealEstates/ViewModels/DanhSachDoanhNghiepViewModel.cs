using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.ViewModels
{
    public class DanhSachDoanhNghiepViewModel
    {
        public IEnumerable<DoanhNghiepBDS> DoanhNghiepBDSs { get; set; }
    }
}