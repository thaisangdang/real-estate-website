using RealEstates.Helper;
using RealEstates.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.ViewModels
{
    public class DanhSachDuAnViewModel
    {
        [Display(Name = "Tỉnh thành phố")]
        public int TinhThanhPhoId { get; set; }

        [Display(Name = "Quận huyện")]
        public int QuanHuyenId { get; set; }

        [Display(Name = "Loại dự án")]
        public int LoaiDuAnId { get; set; }

        [Display(Name = "Trạng thái dự án")]
        public int TrangThai { get; set; } // dùng cho chức năng tìm kiếm

        public IEnumerable<LoaiDuAn> LoaiDuAns { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<DuAn> DuAns { get; set; }

        public IEnumerable<Option> TrangThaiDuAn { get; set; }

        public string GetLableColor(int trangThai)
        {
            string color = "";
            switch (trangThai)
            {
                case 1:
                    color = "bg-success";
                    break;

                case 2:
                    color = "bg-info";
                    break;

                case 3:
                    color = "bg-secondary";
                    break;

                case 4:
                    color = "bg-danger";
                    break;

                default:
                    break;
            }
            return color;
        }
    }
}