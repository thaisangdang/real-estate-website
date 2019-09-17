namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DuAn", "TongDienTich", c => c.Int(nullable: false));
            DropColumn("dbo.DuAn", "GiaTu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DuAn", "GiaTu", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.DuAn", "TongDienTich", c => c.String(nullable: false));
        }
    }
}
