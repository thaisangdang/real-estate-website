namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhaDat", "KhachHang_Id", "dbo.KhachHang");
            DropIndex("dbo.NhaDat", new[] { "KhachHang_Id" });
            DropColumn("dbo.NhaDat", "KhachHang_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhaDat", "KhachHang_Id", c => c.Int());
            CreateIndex("dbo.NhaDat", "KhachHang_Id");
            AddForeignKey("dbo.NhaDat", "KhachHang_Id", "dbo.KhachHang", "Id");
        }
    }
}
