using RealEstates.Helper;
using RealEstates.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.ViewModels
{
    public class DanhSachNhaDatViewModel
    {
        public string KeyWord { get; set; }

        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }

        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }

        [Display(Name = "Dự án")]
        public int DuAnId { get; set; }

        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }

        [Display(Name = "Loại dự án")]
        public int LoaiDuAnId { get; set; }
        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        [Display(Name = "Diện tích")]
        public int DienTichId { get; set; }
        public IEnumerable<Option> DienTichs { get; set; }

        [Display(Name = "Khoảng giá")]
        public int KhoangGiaId { get; set; }
        public IEnumerable<Option> KhoangGias { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }

        public IEnumerable<NhaDat> NhaDats { get; set; }
    }
}