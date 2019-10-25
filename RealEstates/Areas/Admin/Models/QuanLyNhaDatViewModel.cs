using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class QuanLyNhaDatViewModel
    {
        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }

        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }

        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }

        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }

        public IEnumerable<NhaDat> NhaDats { get; set; }

    }
}