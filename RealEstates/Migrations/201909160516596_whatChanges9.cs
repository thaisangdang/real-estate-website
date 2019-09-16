namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges9 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Quận huyện", newName: "QuanHuyen");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.QuanHuyen", newName: "Quận huyện");
        }
    }
}
