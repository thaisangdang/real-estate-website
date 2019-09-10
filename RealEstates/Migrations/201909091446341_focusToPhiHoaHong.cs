namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class focusToPhiHoaHong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhiHoaHong", "DonViDuAn", c => c.String(maxLength: 200));
            AddColumn("dbo.PhiHoaHong", "GiaDonViDuAn", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.PhiHoaHong", "PhanTramHoaHong", c => c.Double(nullable: false));
            AddColumn("dbo.PhiHoaHong", "PhiKhac", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.PhiHoaHong", "TongChi", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.PhiHoaHong", "NguoiChi", c => c.String());
            DropColumn("dbo.PhiHoaHong", "SoTien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhiHoaHong", "SoTien", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.PhiHoaHong", "NguoiChi");
            DropColumn("dbo.PhiHoaHong", "TongChi");
            DropColumn("dbo.PhiHoaHong", "PhiKhac");
            DropColumn("dbo.PhiHoaHong", "PhanTramHoaHong");
            DropColumn("dbo.PhiHoaHong", "GiaDonViDuAn");
            DropColumn("dbo.PhiHoaHong", "DonViDuAn");
        }
    }
}
