using Microsoft.AspNet.Identity.EntityFramework;
using RealEstates.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstates.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DuAn> DuAns { get; set; }
        public DbSet<LoaiDuAn> LoaiDuAns { get; set; }
        public DbSet<TinhThanhPho> TinhThanhPhos { get; set; }
        //public DbSet<LoaiDonViDuAn> LoaiDonViDuAns { get; set; }
        //public DbSet<DonViDuAn> DonViDuAns { get; set; }
        public DbSet<NhanVienSales> NhanVienSales { get; set; }
        public DbSet<PhiHoaHong> PhiHoaHongs { get; set; }

        public ApplicationDbContext()
            : base("name=RealEstates", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}