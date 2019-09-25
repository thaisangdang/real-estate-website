namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuAn", "SoSanPham", c => c.Int(nullable: false));
            AddColumn("dbo.PhanCongSanPham", "SanPham", c => c.String());
            AddColumn("dbo.PhanCongSanPham", "GiaSanPham", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.DuAn", "SoDonViSanPham");
            DropColumn("dbo.PhanCongSanPham", "DonViSanPham");
            DropColumn("dbo.PhanCongSanPham", "GiaDonViSanPham");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanCongSanPham", "GiaDonViSanPham", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.PhanCongSanPham", "DonViSanPham", c => c.String());
            AddColumn("dbo.DuAn", "SoDonViSanPham", c => c.Int(nullable: false));
            DropColumn("dbo.PhanCongSanPham", "GiaSanPham");
            DropColumn("dbo.PhanCongSanPham", "SanPham");
            DropColumn("dbo.DuAn", "SoSanPham");
        }
    }
}
