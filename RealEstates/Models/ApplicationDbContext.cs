﻿using Microsoft.AspNet.Identity.EntityFramework;
using RealEstates.Areas.Admin.Models;
using System.Data.Entity;

namespace RealEstates.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<LoaiDuAn> LoaiDuAns { get; set; }
        public DbSet<DuAn> DuAns { get; set; }
        public DbSet<LoaiNhaDat> LoaiNhaDats { get; set; }
        public DbSet<NhaDat> NhaDats { get; set; }
        public DbSet<TinRaoBDS> TinRaoBDSs { get; set; }
        public DbSet<TinhThanhPho> TinhThanhPhos { get; set; }
        public DbSet<QuanHuyen> QuanHuyens { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhiHoaHong> PhiHoaHongs { get; set; }
        public DbSet<PhanCongSales> PhanCongSales { get; set; }
        public DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<DoanhNghiepBDS> DoanhNghiepBDSs { get; set; }

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