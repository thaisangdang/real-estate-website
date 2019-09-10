namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedTinhThanhPho : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonViDuAn", "DuAn_Id", "dbo.DuAn");
            DropForeignKey("dbo.DonViDuAn", "LoaiDonVi_Id", "dbo.LoaiDonViDuAn");
            DropForeignKey("dbo.DonViDuAn", "NhanVienSales_Id", "dbo.NhanVienSales");
            DropForeignKey("dbo.PhiHoaHong", "DonViDuAn_Id", "dbo.DonViDuAn");
            DropIndex("dbo.DonViDuAn", new[] { "DuAn_Id" });
            DropIndex("dbo.DonViDuAn", new[] { "LoaiDonVi_Id" });
            DropIndex("dbo.DonViDuAn", new[] { "NhanVienSales_Id" });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoaiDonViDuAn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        MoTa = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonViDuAn",
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PhiHoaHong", "DonViDuAn_Id", c => c.Int());
            CreateIndex("dbo.PhiHoaHong", "DonViDuAn_Id");
            CreateIndex("dbo.DonViDuAn", "NhanVienSales_Id");
            CreateIndex("dbo.DonViDuAn", "LoaiDonVi_Id");
            CreateIndex("dbo.DonViDuAn", "DuAn_Id");
            AddForeignKey("dbo.PhiHoaHong", "DonViDuAn_Id", "dbo.DonViDuAn", "Id");
            AddForeignKey("dbo.DonViDuAn", "NhanVienSales_Id", "dbo.NhanVienSales", "Id");
            AddForeignKey("dbo.DonViDuAn", "LoaiDonVi_Id", "dbo.LoaiDonViDuAn", "Id");
            AddForeignKey("dbo.DonViDuAn", "DuAn_Id", "dbo.DuAn", "Id");
        }
    }
}
