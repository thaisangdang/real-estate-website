namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges24 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DuAn", "TongSpDaBanHoacChoThue");
            DropColumn("dbo.DuAn", "TongSpDaTinhHoaHong");
            DropColumn("dbo.DuAn", "TongDoanhThuHienTai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DuAn", "TongDoanhThuHienTai", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.DuAn", "TongSpDaTinhHoaHong", c => c.Int(nullable: false));
            AddColumn("dbo.DuAn", "TongSpDaBanHoacChoThue", c => c.Int(nullable: false));
        }
    }
}
