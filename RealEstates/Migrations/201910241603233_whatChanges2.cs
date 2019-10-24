namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaiViet", "AnhDaiDien", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaiViet", "AnhDaiDien");
        }
    }
}
