namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TinRaoBDS", "NhaDat_Id", "dbo.NhaDat");
            DropIndex("dbo.TinRaoBDS", new[] { "NhaDat_Id" });
            DropColumn("dbo.TinRaoBDS", "NhaDat_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "NhaDat_Id", c => c.Int());
            CreateIndex("dbo.TinRaoBDS", "NhaDat_Id");
            AddForeignKey("dbo.TinRaoBDS", "NhaDat_Id", "dbo.NhaDat", "Id");
        }
    }
}
