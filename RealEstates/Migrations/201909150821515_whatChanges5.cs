namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TinhThanhPho", "Ten", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TinhThanhPho", "Ten", c => c.String(maxLength: 200));
        }
    }
}
