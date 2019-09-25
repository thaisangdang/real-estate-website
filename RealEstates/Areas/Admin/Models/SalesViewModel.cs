using RealEstates.Helper;
using RealEstates.Models;
using RealEstates.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class SalesViewModel
    {
        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }

        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }

        [Display(Name = "Loại dự án")]
        public int LoaiDuAnId { get; set; }

        [Display(Name = "Trạng thái dự án")]
        public int TrangThai { get; set; }

        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<Option> TrangThaiDuAn { get; set; }

        public IEnumerable<DuAnViewModel> DuAns { get; set; }

    }
}