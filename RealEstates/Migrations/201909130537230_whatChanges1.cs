namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhanCongDuAn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DuAnId = c.Int(nullable: false),
                        DonViDuAn = c.String(),
                        GiaDonViDuAn = c.Decimal(nullable: false, storeType: "money"),
                        PhanTramHoaHong = c.Double(nullable: false),
                        NhanVienSalesId = c.Int(nullable: false),
                        NguoiChi = c.String(),
                        NgayChi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienSalesId, cascadeDelete: false)
                .Index(t => t.DuAnId)
                .Index(t => t.NhanVienSalesId);
            
            AddColumn("dbo.PhiHoaHong", "PhanCongDuAnId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhiHoaHong", "PhanCongDuAnId");
            AddForeignKey("dbo.PhiHoaHong", "PhanCongDuAnId", "dbo.PhanCongDuAn", "Id", cascadeDelete: false);
            DropColumn("dbo.PhiHoaHong", "DonViDuAn");
            DropColumn("dbo.PhiHoaHong", "GiaDonViDuAn");
            DropColumn("dbo.PhiHoaHong", "PhanTramHoaHong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhiHoaHong", "PhanTramHoaHong", c => c.Double(nullable: false));
            AddColumn("dbo.PhiHoaHong", "GiaDonViDuAn", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.PhiHoaHong", "DonViDuAn", c => c.String());
            DropForeignKey("dbo.PhiHoaHong", "PhanCongDuAnId", "dbo.PhanCongDuAn");
            DropForeignKey("dbo.PhanCongDuAn", "NhanVienSalesId", "dbo.NhanVien");
            DropForeignKey("dbo.PhanCongDuAn", "DuAnId", "dbo.DuAn");
            DropIndex("dbo.PhanCongDuAn", new[] { "NhanVienSalesId" });
            DropIndex("dbo.PhanCongDuAn", new[] { "DuAnId" });
            DropIndex("dbo.PhiHoaHong", new[] { "PhanCongDuAnId" });
            DropColumn("dbo.PhiHoaHong", "PhanCongDuAnId");
            DropTable("dbo.PhanCongDuAn");
        }
    }
}
