using RealEstates.Helper;
using RealEstates.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.ViewModels
{
    public class HomeViewModel
    {
        public string KeyWord { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }
        public IEnumerable<NhaDat> NhaDats { get; set; }
        public IEnumerable<TinRaoBDS> TinRaoBDSs { get; set; }
        
        [Display(Name = "Loại nhà đất")]
        public int LoaiNhaDatId { get; set; }
        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }

        [Display(Name = "Loại dự án")]
        public int LoaiDuAnId { get; set; }
        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        [Display(Name = "Loại tin rao")]
        public int LoaiTinRaoId { get; set; }
        public IEnumerable<Option> LoaiTinRaoBDS { get; set; }

        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }
        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }
        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        [Display(Name = "Diện tích")]
        public int DienTichId { get; set; }
        public IEnumerable<Option> DienTichs { get; set; }

        [Display(Name = "Khoảng giá")]
        public int KhoangGiaId { get; set; }
        public IEnumerable<Option> KhoangGias { get; set; }

        public int LoaiTimKiemId { get; set; }
        public IEnumerable<Option> LoaiTimKiems { get; set; }

        public HomeViewModel()
        {
            LoaiTimKiemId = 1;
            DienTichs = SelectOptions.getDienTich;
            KhoangGias = SelectOptions.getKhoangGia;
        }
    }
}
