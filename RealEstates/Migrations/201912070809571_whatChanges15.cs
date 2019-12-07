namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NhaDat", "DiaChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhaDat", "DiaChi", c => c.String());
        }
    }
}
