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
                        TongDienTich = c.String(nullable: false),
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
                        SoDonViDuAn = c.Int(nullable: false),
                        AnhDaiDien = c.String(),
                        NgayDang = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiDuAn", t => t.LoaiDuAnId, cascadeDelete: true)
                .ForeignKey("dbo.TinhThanhPho", t => t.TinhThanhPhoId, cascadeDelete: true)
                .Index(t => t.LoaiDuAnId)
                .Index(t => t.TinhThanhPhoId);
            
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
                "dbo.TinhThanhPho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 200),
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
                        PhanQuyen = c.String(nullable: false),
                        Account = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhiHoaHong",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonViDuAn = c.String(),
                        GiaDonViDuAn = c.Decimal(nullable: false, storeType: "money"),
                        PhanTramHoaHong = c.Double(nullable: false),
                        PhiKhac = c.Decimal(nullable: false, storeType: "money"),
                        TongChi = c.Decimal(nullable: false, storeType: "money"),
                        NhanVienId = c.Int(nullable: false),
                        NguoiChi = c.String(),
                        NgayChi = c.DateTime(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienId, cascadeDelete: true)
                .Index(t => t.NhanVienId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PhiHoaHong", "NhanVienId", "dbo.NhanVien");
            DropForeignKey("dbo.DuAn", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropForeignKey("dbo.DuAn", "LoaiDuAnId", "dbo.LoaiDuAn");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PhiHoaHong", new[] { "NhanVienId" });
            DropIndex("dbo.DuAn", new[] { "TinhThanhPhoId" });
            DropIndex("dbo.DuAn", new[] { "LoaiDuAnId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhiHoaHong");
            DropTable("dbo.NhanVien");
            DropTable("dbo.TinhThanhPho");
            DropTable("dbo.LoaiDuAn");
            DropTable("dbo.DuAn");
        }
    }
}
