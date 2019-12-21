namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Cost = c.Double(nullable: false),
                        Descripition = c.String(nullable: false, maxLength: 1000),
                        ImageURL = c.String(),
                        CategoryID = c.Int(nullable: false),
                        NumberOfSold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryID" });
            DropTable("dbo.Items");
        }
    }
}
