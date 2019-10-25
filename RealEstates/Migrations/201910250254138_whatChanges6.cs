namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhaDat", "DiaChi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhaDat", "DiaChi");
        }
    }
}
