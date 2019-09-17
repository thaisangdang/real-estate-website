namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuAn", "GiaTu", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DuAn", "GiaTu");
        }
    }
}
