namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhanVien", "PhanQuyen_Id", "dbo.AspNetRoles");
            DropIndex("dbo.NhanVien", new[] { "PhanQuyen_Id" });
            DropColumn("dbo.NhanVien", "PhanQuyen_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanVien", "PhanQuyen_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.NhanVien", "PhanQuyen_Id");
            AddForeignKey("dbo.NhanVien", "PhanQuyen_Id", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
