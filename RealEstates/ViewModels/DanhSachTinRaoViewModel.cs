﻿using RealEstates.Helper;
using RealEstates.Models;
using System.Collections.Generic;

namespace RealEstates.ViewModels
{
    public class DanhSachTinRaoViewModel
    {
        public string KeyWord { get; set; }

        public string Title { get; set; }

        public IEnumerable<TinRaoBDS> TinRaoBDSs { get; set; }

        public int TinhThanhPhoId { get; set; }
        public IEnumerable<TinhThanhPho> TinhThanhPhos { get; set; }

        public int QuanHuyenId { get; set; }
        public IEnumerable<QuanHuyen> QuanHuyens { get; set; }

        public int LoaiTinRaoId { get; set; }
        public IEnumerable<Option> LoaiTinRaoBDS { get; set; }

        public int LoaiNhaDatId { get; set; }
        public IEnumerable<LoaiNhaDat> LoaiNhaDats { get; set; }

        public int TrangThai { get; set; }
        public IEnumerable<Option> TrangThaiTinRao { get; set; }

        public int ThoiHanDangTin { get; set; }
        public IEnumerable<Option> ThoiHanDangTins { get; set; }

        public int DienTichId { get; set; }
        public IEnumerable<Option> DienTichs { get; set; }

        public int KhoangGiaId { get; set; }
        public IEnumerable<Option> KhoangGias { get; set; }

        public string GetLableColor(int trangThai)
        {
            string color = "";
            switch (trangThai)
            {
                case 1:
                    color = "bg-secondary";
                    break;

                case 2:
                    color = "bg-success";
                    break;

                case 3:
                    color = "bg-secondary";
                    break;

                default:
                    break;
            }
            return color;
        }
    }
}