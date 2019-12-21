namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ItemID })
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ItemID", "dbo.Items");
            DropIndex("dbo.OrderItems", new[] { "ItemID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropTable("dbo.OrderItems");
        }
    }
}
