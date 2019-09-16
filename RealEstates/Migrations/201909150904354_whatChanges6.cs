namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanCongDuAn", "DonViSanPham", c => c.String());
            AddColumn("dbo.PhanCongDuAn", "IsRent", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhanCongDuAn", "GiaThueThangDau", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.PhanCongDuAn", "DonViDuAn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanCongDuAn", "DonViDuAn", c => c.String());
            DropColumn("dbo.PhanCongDuAn", "GiaThueThangDau");
            DropColumn("dbo.PhanCongDuAn", "IsRent");
            DropColumn("dbo.PhanCongDuAn", "DonViSanPham");
        }
    }
}
