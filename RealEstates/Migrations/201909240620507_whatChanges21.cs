namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuAn", "TongSpDaBanHoacChoThue", c => c.Int(nullable: false));
            AddColumn("dbo.DuAn", "TongSpDaTinhHoaHong", c => c.Int(nullable: false));
            AddColumn("dbo.DuAn", "TongDoanhThuHienTai", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DuAn", "TongDoanhThuHienTai");
            DropColumn("dbo.DuAn", "TongSpDaTinhHoaHong");
            DropColumn("dbo.DuAn", "TongSpDaBanHoacChoThue");
        }
    }
}
