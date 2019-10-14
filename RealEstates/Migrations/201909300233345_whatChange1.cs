namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChange1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhiHoaHong", "PhiKhac");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhiHoaHong", "PhiKhac", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
