namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGhiChu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhiHoaHong", "GhiChu", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhiHoaHong", "GhiChu");
        }
    }
}
