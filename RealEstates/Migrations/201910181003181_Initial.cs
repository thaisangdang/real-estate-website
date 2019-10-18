namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DuAn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDuAn = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        GiaTu = c.Decimal(nullable: false, storeType: "money"),
                        ChuDauTu = c.String(nullable: false),
                        TongDienTich = c.Int(nullable: false),
                        TienDoDuAn = c.String(nullable: false),
                        LoaiDuAnId = c.Int(nullable: false),
                        QuyMoDuAn = c.String(nullable: false),
                        GioiThieuDuAn = c.String(nullable: false),
                        ViTri = c.String(nullable: false),
                        HaTang = c.String(nullable: false),
                        ThietKe = c.String(nullable: false),
                        MatBang = c.String(nullable: false),
                        Media = c.String(nullable: false),
                        HoTroTaiChinh = c.String(nullable: false),
                        TinhThanhPhoId = c.Int(nullable: false),
                        QuanHuyenId = c.Int(nullable: false),
                        SoSanPham = c.Int(nullable: false),
                        AnhDaiDien = c.String(),
                        NguoiDangId = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                        NgayDang = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiDuAn", t => t.LoaiDuAnId, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.NguoiDangId, cascadeDelete: true)
                .ForeignKey("dbo.QuanHuyen", t => t.QuanHuyenId, cascadeDelete: true)
                .ForeignKey("dbo.TinhThanhPho", t => t.TinhThanhPhoId, cascadeDelete: true)
                .Index(t => t.LoaiDuAnId)
                .Index(t => t.TinhThanhPhoId)
                .Index(t => t.QuanHuyenId)
                .Index(t => t.NguoiDangId);
            
            CreateTable(
                "dbo.LoaiDuAn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        SoDienThoai = c.String(nullable: false),
                        PhongBanId = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                        AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.PhongBan", t => t.PhongBanId, cascadeDelete: true)
                .Index(t => t.PhongBanId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PhanCongSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NhaDatId = c.Int(nullable: false),
                        NhanVienSalesId = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                        PhanTramHoaHong = c.Double(nullable: false),
                        DaTinhHoaHong = c.Boolean(nullable: false),
                        NguoTao = c.String(),
                        NgayTao = c.DateTime(),
                        DuAn_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhaDat", t => t.NhaDatId, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienSalesId, cascadeDelete: true)
                .ForeignKey("dbo.DuAn", t => t.DuAn_Id)
                .Index(t => t.NhaDatId)
                .Index(t => t.NhanVienSalesId)
                .Index(t => t.DuAn_Id);
            
            CreateTable(
                "dbo.NhaDat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false),
                        DuAnId = c.Int(nullable: false),
                        LoaiNhaDatId = c.Int(nullable: false),
                        GiaBan = c.Decimal(nullable: false, storeType: "money"),
                        GiaThue = c.Decimal(nullable: false, storeType: "money"),
                        DienTich = c.Int(nullable: false),
                        HuongNha = c.String(),
                        SoPhong = c.Int(nullable: false),
                        ThongTinMoTa = c.String(),
                        Media = c.String(),
                        TuKhoa = c.String(),
                        BanDo = c.String(),
                        NgayTao = c.DateTime(),
                        TinhThanhPhoId = c.Int(nullable: false),
                        QuanHuyenId = c.Int(nullable: false),
                        KhachHang_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DuAn", t => t.DuAnId, cascadeDelete: false)
                .ForeignKey("dbo.LoaiNhaDat", t => t.LoaiNhaDatId, cascadeDelete: true)
                .ForeignKey("dbo.QuanHuyen", t => t.QuanHuyenId, cascadeDelete: true)
                .ForeignKey("dbo.TinhThanhPho", t => t.TinhThanhPhoId, cascadeDelete: true)
                .ForeignKey("dbo.KhachHang", t => t.KhachHang_Id)
                .Index(t => t.DuAnId)
                .Index(t => t.LoaiNhaDatId)
                .Index(t => t.TinhThanhPhoId)
                .Index(t => t.QuanHuyenId)
                .Index(t => t.KhachHang_Id);
            
            CreateTable(
                "dbo.LoaiNhaDat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                        IsRent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuanHuyen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        Prefix = c.String(),
                        TinhThanhPhoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TinhThanhPho", t => t.TinhThanhPhoId, cascadeDelete: false)
                .Index(t => t.TinhThanhPhoId);
            
            CreateTable(
                "dbo.TinhThanhPho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TinRaoBDS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NhaDatId = c.Int(nullable: false),
                        LoaiTinRao = c.Int(nullable: false),
                        NgayBatDauDangTinRao = c.DateTime(nullable: false),
                        NgayKetThucDangTinRao = c.DateTime(nullable: false),
                        KhachHangId = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KhachHang", t => t.KhachHangId, cascadeDelete: true)
                .ForeignKey("dbo.NhaDat", t => t.NhaDatId, cascadeDelete: true)
                .Index(t => t.NhaDatId)
                .Index(t => t.KhachHangId);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.PhiHoaHong",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhanCongSalesId = c.Int(nullable: false),
                        TongChi = c.Decimal(nullable: false, storeType: "money"),
                        NguoiTaoId = c.Int(nullable: false),
                        NgayTao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanVien", t => t.NguoiTaoId, cascadeDelete: true)
                .ForeignKey("dbo.PhanCongSales", t => t.PhanCongSalesId, cascadeDelete: false)
                .Index(t => t.PhanCongSalesId)
                .Index(t => t.NguoiTaoId);
            
            CreateTable(
                "dbo.PhongBan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PhanCongSales", "DuAn_Id", "dbo.DuAn");
            DropForeignKey("dbo.NhanVien", "PhongBanId", "dbo.PhongBan");
            DropForeignKey("dbo.PhiHoaHong", "PhanCongSalesId", "dbo.PhanCongSales");
            DropForeignKey("dbo.PhiHoaHong", "NguoiTaoId", "dbo.NhanVien");
            DropForeignKey("dbo.PhanCongSales", "NhanVienSalesId", "dbo.NhanVien");
            DropForeignKey("dbo.TinRaoBDS", "NhaDatId", "dbo.NhaDat");
            DropForeignKey("dbo.TinRaoBDS", "KhachHangId", "dbo.KhachHang");
            DropForeignKey("dbo.NhaDat", "KhachHang_Id", "dbo.KhachHang");
            DropForeignKey("dbo.KhachHang", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuanHuyen", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropForeignKey("dbo.NhaDat", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropForeignKey("dbo.DuAn", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropForeignKey("dbo.NhaDat", "QuanHuyenId", "dbo.QuanHuyen");
            DropForeignKey("dbo.DuAn", "QuanHuyenId", "dbo.QuanHuyen");
            DropForeignKey("dbo.PhanCongSales", "NhaDatId", "dbo.NhaDat");
            DropForeignKey("dbo.NhaDat", "LoaiNhaDatId", "dbo.LoaiNhaDat");
            DropForeignKey("dbo.NhaDat", "DuAnId", "dbo.DuAn");
            DropForeignKey("dbo.DuAn", "NguoiDangId", "dbo.NhanVien");
            DropForeignKey("dbo.NhanVien", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DuAn", "LoaiDuAnId", "dbo.LoaiDuAn");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PhiHoaHong", new[] { "NguoiTaoId" });
            DropIndex("dbo.PhiHoaHong", new[] { "PhanCongSalesId" });
            DropIndex("dbo.KhachHang", new[] { "AccountId" });
            DropIndex("dbo.TinRaoBDS", new[] { "KhachHangId" });
            DropIndex("dbo.TinRaoBDS", new[] { "NhaDatId" });
            DropIndex("dbo.QuanHuyen", new[] { "TinhThanhPhoId" });
            DropIndex("dbo.NhaDat", new[] { "KhachHang_Id" });
            DropIndex("dbo.NhaDat", new[] { "QuanHuyenId" });
            DropIndex("dbo.NhaDat", new[] { "TinhThanhPhoId" });
            DropIndex("dbo.NhaDat", new[] { "LoaiNhaDatId" });
            DropIndex("dbo.NhaDat", new[] { "DuAnId" });
            DropIndex("dbo.PhanCongSales", new[] { "DuAn_Id" });
            DropIndex("dbo.PhanCongSales", new[] { "NhanVienSalesId" });
            DropIndex("dbo.PhanCongSales", new[] { "NhaDatId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.NhanVien", new[] { "AccountId" });
            DropIndex("dbo.NhanVien", new[] { "PhongBanId" });
            DropIndex("dbo.DuAn", new[] { "NguoiDangId" });
            DropIndex("dbo.DuAn", new[] { "QuanHuyenId" });
            DropIndex("dbo.DuAn", new[] { "TinhThanhPhoId" });
            DropIndex("dbo.DuAn", new[] { "LoaiDuAnId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhongBan");
            DropTable("dbo.PhiHoaHong");
            DropTable("dbo.KhachHang");
            DropTable("dbo.TinRaoBDS");
            DropTable("dbo.TinhThanhPho");
            DropTable("dbo.QuanHuyen");
            DropTable("dbo.LoaiNhaDat");
            DropTable("dbo.NhaDat");
            DropTable("dbo.PhanCongSales");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.NhanVien");
            DropTable("dbo.LoaiDuAn");
            DropTable("dbo.DuAn");
        }
    }
}
