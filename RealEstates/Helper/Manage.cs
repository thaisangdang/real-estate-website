using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RealEstates.Helper
{
    public class Manage
    {
        public static List<SearchOption> dienTich;
        public static List<SearchOption> khoangGia { get; set; }
        public static List<SearchOption> thoiGian { get; set; }

        public static List<SearchOption> getDienTich
        {
            get
            {
                if(dienTich == null)
                {
                    dienTich = new List<SearchOption>();
                    dienTich.Add(new SearchOption() { Id = 1, Text = "Dưới 20 mét vuông"});
                    dienTich.Add(new SearchOption() { Id = 2, Text = "20 - 50 mét vuông"});
                    dienTich.Add(new SearchOption() { Id = 3, Text = "50 - 100 mét vuông"});
                    dienTich.Add(new SearchOption() { Id = 4, Text = "Trên 100 mét vuông"});
                }
                return dienTich;
            }
        }

        public static List<SearchOption> getKhoangGia
        {
            get
            {
                if (khoangGia == null)
                {
                    khoangGia = new List<SearchOption>();
                    khoangGia.Add(new SearchOption() { Id = 1, Text = "Dưới 2 triệu" });
                    khoangGia.Add(new SearchOption() { Id = 2, Text = "Từ 2 triệu đến dưới 5 triệu" });
                    khoangGia.Add(new SearchOption() { Id = 3, Text = "Trên 5 triệu" });
                    khoangGia.Add(new SearchOption() { Id = 11, Text = "Dưới 500 triệu" });
                    khoangGia.Add(new SearchOption() { Id = 12, Text = "Từ 500 triệu đến dưới 2 tỉ" });
                    khoangGia.Add(new SearchOption() { Id = 13, Text = "Trên 2 tỉ" });
                }
                return khoangGia;
            }
        }

        public static List<SearchOption> getThoiGian
        {
            get
            {
                if (thoiGian == null)
                {
                    thoiGian = new List<SearchOption>();
                    thoiGian.Add(new SearchOption() { Id = 1, Text = "Dưới 6 tháng" });
                    thoiGian.Add(new SearchOption() { Id = 2, Text = "Từ 6 tháng đến dưới 1 năm" });
                    thoiGian.Add(new SearchOption() { Id = 3, Text = "Trên 1 năm" });
                }
                return thoiGian;
            }
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }

    public class SearchOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

}