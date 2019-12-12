using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Areas.Admin.Models
{
    public class QuanLyTinRaoViewModel
    {
        public int TinhThanhPhoId { get; set; }

        public int QuanHuyenId { get; set; }

        public int LoaiTinRaoId { get; set; }

        public int TrangThai { get; set; }

        public IEnumerable<TinRaoBDS> TinRaoBDSs { get; set; }

        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public IEnumerable<Option> LoaiTinRaoBDS { get; set; }

        public IEnumerable<Option> TrangThaiTinRao { get; set; }

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