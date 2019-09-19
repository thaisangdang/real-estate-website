﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RealEstates.Helper
{
    public static class SelectOptions
    {
        public static List<Option> DienTich;
        public static List<Option> KhoangGia { get; set; }
        public static List<Option> ThoiGian { get; set; }
        public static List<Option> TrangThaiNhanVien { get; set; }
        public static List<Option> TrangThaiDuAn { get; set; }

        public static List<Option> getTrangThaiDuAn
        {
            get
            {
                if (TrangThaiDuAn == null)
                {
                    TrangThaiDuAn = new List<Option>();
                    TrangThaiDuAn.Add(new Option() { Id = 1, Text = "Mở bán" } ); // mặc định
                    TrangThaiDuAn.Add(new Option() { Id = 2, Text = "Dự án mẫu" } );
                    TrangThaiDuAn.Add(new Option() { Id = 3, Text = "Tạm ngưng" } );
                    TrangThaiDuAn.Add(new Option() { Id = 4, Text = "Đã bán hết" } ); // thuộc tính số đơn vị dự án là để xử lý phân công dự án cho nhân viên sales
                }
                return TrangThaiDuAn;
            }
        }

        public static List<Option> getTrangThaiNhanVien
        {
            get
            {
                if (TrangThaiNhanVien == null)
                {
                    TrangThaiNhanVien = new List<Option>();
                    TrangThaiNhanVien.Add(new Option() { Id = 1, Text = "Đang làm việc" });
                    TrangThaiNhanVien.Add(new Option() { Id = 2, Text = "Đã chuyển phòng ban" });
                    TrangThaiNhanVien.Add(new Option() { Id = 3, Text = "Đã nghỉ việc" });
                }
                return TrangThaiNhanVien;
            }
        }

        public static List<Option> getDienTich
        {
            get
            {
                if(DienTich == null)
                {
                    DienTich = new List<Option>();
                    DienTich.Add(new Option() { Id = 1, Text = "Dưới 20 mét vuông"});
                    DienTich.Add(new Option() { Id = 2, Text = "20 - 50 mét vuông"});
                    DienTich.Add(new Option() { Id = 3, Text = "50 - 100 mét vuông"});
                    DienTich.Add(new Option() { Id = 4, Text = "Trên 100 mét vuông"});
                }
                return DienTich;
            }
        }

        public static List<Option> getKhoangGia
        {
            get
            {
                if (KhoangGia == null)
                {
                    KhoangGia = new List<Option>();
                    KhoangGia.Add(new Option() { Id = 1, Text = "Dưới 2 triệu" });
                    KhoangGia.Add(new Option() { Id = 2, Text = "Từ 2 triệu đến dưới 5 triệu" });
                    KhoangGia.Add(new Option() { Id = 3, Text = "Trên 5 triệu" });
                    KhoangGia.Add(new Option() { Id = 4, Text = "Dưới 500 triệu" });
                    KhoangGia.Add(new Option() { Id = 5, Text = "Từ 500 triệu đến dưới 2 tỉ" });
                    KhoangGia.Add(new Option() { Id = 6, Text = "Trên 2 tỉ" });
                }
                return KhoangGia;
            }
        }

        public static List<Option> getThoiGian
        {
            get
            {
                if (ThoiGian == null)
                {
                    ThoiGian = new List<Option>();
                    ThoiGian.Add(new Option() { Id = 1, Text = "Dưới 6 tháng" });
                    ThoiGian.Add(new Option() { Id = 2, Text = "Từ 6 tháng đến dưới 1 năm" });
                    ThoiGian.Add(new Option() { Id = 3, Text = "Trên 1 năm" });
                }
                return ThoiGian;
            }
        }
    }

    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

}