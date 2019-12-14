﻿using RealEstates.Helper;
using RealEstates.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<NhaDat> NhaDats { get; set; }

        public IEnumerable<TinRaoBDS> TinRaoBDSs { get; set; }

        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }

        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        public IEnumerable<Option> LoaiTinRaoBDS { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<Option> DienTichs { get; set; }

        public IEnumerable<Option> KhoangGias { get; set; }

        [Display(Name = "Loại dự án")]
        public int LoaiDuAnId { get; set; }

        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }

        [Display(Name = "Loại tin rao")]
        public int LoaiTinRaoId { get; set; }

        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }

        [Display(Name = "Diện tích")]
        public int DienTichId { get; set; }

        [Display(Name = "Khoảng giá")]
        public int KhoangGiaId { get; set; }

        public HomeViewModel()
        {
            DienTichs = SelectOptions.getDienTich;
            KhoangGias = SelectOptions.getKhoangGia;
        }
    }
}