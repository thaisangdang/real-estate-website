namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quận huyện",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        Prefix = c.Int(nullable: false),
                        TinhThanhPhoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TinhThanhPho", t => t.TinhThanhPhoId, cascadeDelete: true)
                .Index(t => t.TinhThanhPhoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quận huyện", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropIndex("dbo.Quận huyện", new[] { "TinhThanhPhoId" });
            DropTable("dbo.Quận huyện");
        }
    }
}
