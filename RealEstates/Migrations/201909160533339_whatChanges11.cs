namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuAn", "QuanHuyenId", c => c.Int(nullable: false));
            CreateIndex("dbo.DuAn", "QuanHuyenId");
            AddForeignKey("dbo.DuAn", "QuanHuyenId", "dbo.QuanHuyen", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuAn", "QuanHuyenId", "dbo.QuanHuyen");
            DropIndex("dbo.DuAn", new[] { "QuanHuyenId" });
            DropColumn("dbo.DuAn", "QuanHuyenId");
        }
    }
}
