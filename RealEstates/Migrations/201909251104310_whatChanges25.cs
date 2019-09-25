namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanCongSanPham", "DaTinhHoaHong", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhanCongSanPham", "DaTinhHoaHong");
        }
    }
}
