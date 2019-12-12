namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TinRaoBDS", "HuongNha");
            DropColumn("dbo.TinRaoBDS", "SoPhong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "SoPhong", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "HuongNha", c => c.String());
        }
    }
}
