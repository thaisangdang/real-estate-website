namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanCongSanPham", "GiaDonViSanPham", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.PhanCongSanPham", "GiaDonViDuAn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanCongSanPham", "GiaDonViDuAn", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.PhanCongSanPham", "GiaDonViSanPham");
        }
    }
}
