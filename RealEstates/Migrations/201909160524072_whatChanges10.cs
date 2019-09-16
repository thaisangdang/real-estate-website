namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuanHuyen", "Prefix", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuanHuyen", "Prefix", c => c.Int(nullable: false));
        }
    }
}
