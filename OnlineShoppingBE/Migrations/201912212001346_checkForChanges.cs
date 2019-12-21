namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkForChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "ReciverFullName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "ZIPCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "ZIPCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Orders", "ReciverFullName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Orders", "TotalCost");
        }
    }
}
