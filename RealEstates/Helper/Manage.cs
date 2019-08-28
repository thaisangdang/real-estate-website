using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.Helper
{
    public class Manage
    {
        public static string SESSION = "SESSION";
        public static int PageSize = 20;

        public static List<SearchOption> dienTich;
        public static List<SearchOption> khoangGia { get; set; }
        public static List<SearchOption> thoiGian { get; set; }
    }

    public class SearchOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class Select2Data
    {
        public string Text { get; set; }
        public Select2Child[] childrens { get; set; }
    }

    public class Select2Child
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}