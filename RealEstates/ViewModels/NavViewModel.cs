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

        public static IEnumerable<LoaiDuAn> getLoaiDuAns ()
        {
            if (_context == null)
            {
                _context = new ApplicationDbContext();
            }
            LoaiDuAns = _context.LoaiDuAns.ToList();
            return LoaiDuAns;
        }

    }
}