using RealEstates.Helper;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.ViewModels
{
    public class NavViewModel
    {
        public static ApplicationDbContext _context = new ApplicationDbContext();

        public static IEnumerable<LoaiDuAn> LoaiDuAns;

        public static IEnumerable<LoaiNhaDat> LoaiNhaDats;

        public static IEnumerable<Option> LoaiTinRaoBDS;

        public static IEnumerable<LoaiDuAn> GetLoaiDuAns()
        {
            if (_context == null)
            {
                _context = new ApplicationDbContext();
            }
            return _context.LoaiDuAns.ToList();
        }

        public static IEnumerable<LoaiNhaDat> GetLoaiNhaDats()
        {
            if (_context == null)
            {
                _context = new ApplicationDbContext();
            }
            return _context.LoaiNhaDats.ToList();
        }

        public static IEnumerable<Option> GetLoaiTinRaoBDS()
        {
            if (_context == null)
            {
                _context = new ApplicationDbContext();
            }

            return SelectOptions.getLoaiTinRaoBDS;
        }

    }
}