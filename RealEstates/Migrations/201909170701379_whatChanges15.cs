namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhongBan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhongBan");
        }
    }
}
