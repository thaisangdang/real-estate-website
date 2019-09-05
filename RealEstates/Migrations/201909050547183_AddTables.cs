namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonViSanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoTa = c.String(maxLength: 500),
                        GiaTien = c.Decimal(nullable: false, storeType: "money"),
                        PhanTramHoaHong = c.Double(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        DuAn_Id = c.Int(),
                        LoaiDonVi_Id = c.Int(),
                        NhanVienSales_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DuAn", t => t.DuAn_Id)
                .ForeignKey("dbo.LoaiDonViSanPham", t => t.LoaiDonVi_Id)
                .ForeignKey("dbo.NhanVienSales", t => t.NhanVienSales_Id)
                .Index(t => t.DuAn_Id)
                .Index(t => t.LoaiDonVi_Id)
                .Index(t => t.NhanVienSales_Id);
            
            CreateTable(
                "dbo.LoaiDonViSanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        MoTa = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhanVienSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        SoDienThoai = c.String(maxLength: 13),
                        AccountId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhiHoaHong",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayChi = c.DateTime(nullable: false),
                        SoTien = c.Decimal(nullable: false, storeType: "money"),
                        DonViSanPham_Id = c.Int(),
                        NhanVienSales_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonViSanPham", t => t.DonViSanPham_Id)
                .ForeignKey("dbo.NhanVienSales", t => t.NhanVienSales_Id)
                .Index(t => t.DonViSanPham_Id)
                .Index(t => t.NhanVienSales_Id);
            
            AddColumn("dbo.DuAn", "GiaTu", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.DuAn", "NgayDang", c => c.DateTime());
            AddColumn("dbo.DuAn", "TinhThanhPho_Id", c => c.Int());
            AddColumn("dbo.LoaiDuAn", "ChoThue", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TinhThanhPho", "Ten", c => c.String(maxLength: 200));
            CreateIndex("dbo.DuAn", "TinhThanhPho_Id");
            AddForeignKey("dbo.DuAn", "TinhThanhPho_Id", "dbo.TinhThanhPho", "Id");
            DropColumn("dbo.DuAn", "Gia");
            DropColumn("dbo.DuAn", "IdTinh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DuAn", "IdTinh", c => c.Int(nullable: false));
            AddColumn("dbo.DuAn", "Gia", c => c.Decimal(nullable: false, storeType: "money"));
            DropForeignKey("dbo.PhiHoaHong", "NhanVienSales_Id", "dbo.NhanVienSales");
            DropForeignKey("dbo.PhiHoaHong", "DonViSanPham_Id", "dbo.DonViSanPham");
            DropForeignKey("dbo.DonViSanPham", "NhanVienSales_Id", "dbo.NhanVienSales");
            DropForeignKey("dbo.DonViSanPham", "LoaiDonVi_Id", "dbo.LoaiDonViSanPham");
            DropForeignKey("dbo.DonViSanPham", "DuAn_Id", "dbo.DuAn");
            DropForeignKey("dbo.DuAn", "TinhThanhPho_Id", "dbo.TinhThanhPho");
            DropIndex("dbo.PhiHoaHong", new[] { "NhanVienSales_Id" });
            DropIndex("dbo.PhiHoaHong", new[] { "DonViSanPham_Id" });
            DropIndex("dbo.DuAn", new[] { "TinhThanhPho_Id" });
            DropIndex("dbo.DonViSanPham", new[] { "NhanVienSales_Id" });
            DropIndex("dbo.DonViSanPham", new[] { "LoaiDonVi_Id" });
            DropIndex("dbo.DonViSanPham", new[] { "DuAn_Id" });
            AlterColumn("dbo.TinhThanhPho", "Ten", c => c.String(maxLength: 50));
            DropColumn("dbo.LoaiDuAn", "ChoThue");
            DropColumn("dbo.DuAn", "TinhThanhPho_Id");
            DropColumn("dbo.DuAn", "NgayDang");
            DropColumn("dbo.DuAn", "GiaTu");
            DropTable("dbo.PhiHoaHong");
            DropTable("dbo.NhanVienSales");
            DropTable("dbo.LoaiDonViSanPham");
            DropTable("dbo.DonViSanPham");
        }
    }
}
