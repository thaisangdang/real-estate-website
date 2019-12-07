namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhanCongSales", "DuAn_Id", "dbo.DuAn");
            DropIndex("dbo.PhanCongSales", new[] { "DuAn_Id" });
            RenameColumn(table: "dbo.PhanCongSales", name: "DuAn_Id", newName: "DuAnId");
            AlterColumn("dbo.PhanCongSales", "DuAnId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhanCongSales", "DuAnId");
            AddForeignKey("dbo.PhanCongSales", "DuAnId", "dbo.DuAn", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhanCongSales", "DuAnId", "dbo.DuAn");
            DropIndex("dbo.PhanCongSales", new[] { "DuAnId" });
            AlterColumn("dbo.PhanCongSales", "DuAnId", c => c.Int());
            RenameColumn(table: "dbo.PhanCongSales", name: "DuAnId", newName: "DuAn_Id");
            CreateIndex("dbo.PhanCongSales", "DuAn_Id");
            AddForeignKey("dbo.PhanCongSales", "DuAn_Id", "dbo.DuAn", "Id");
        }
    }
}
