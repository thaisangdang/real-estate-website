namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TinhThanhPho", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TinhThanhPho", "Code");
        }
    }
}
