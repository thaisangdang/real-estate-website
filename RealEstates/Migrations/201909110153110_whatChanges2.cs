namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuAn", "LoaiDuAn_Id", "dbo.LoaiDuAn");
            DropIndex("dbo.DuAn", new[] { "LoaiDuAn_Id" });
            AlterColumn("dbo.DuAn", "LoaiDuAn_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.DuAn", "LoaiDuAn_Id");
            AddForeignKey("dbo.DuAn", "LoaiDuAn_Id", "dbo.LoaiDuAn", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuAn", "LoaiDuAn_Id", "dbo.LoaiDuAn");
            DropIndex("dbo.DuAn", new[] { "LoaiDuAn_Id" });
            AlterColumn("dbo.DuAn", "LoaiDuAn_Id", c => c.Int());
            CreateIndex("dbo.DuAn", "LoaiDuAn_Id");
            AddForeignKey("dbo.DuAn", "LoaiDuAn_Id", "dbo.LoaiDuAn", "Id");
        }
    }
}
