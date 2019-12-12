namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges23 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TinRaoBDS", "BanDo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "BanDo", c => c.String());
        }
    }
}
