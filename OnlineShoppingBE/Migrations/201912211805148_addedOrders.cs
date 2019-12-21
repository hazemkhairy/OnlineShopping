namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReciverFullName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 500),
                        ZIPCode = c.String(nullable: false, maxLength: 20),
                        Country = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        PaymentTypeID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PaymentTypeID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "PaymentTypeID", "dbo.PaymentTypes");
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "PaymentTypeID" });
            DropTable("dbo.Orders");
        }
    }
}
