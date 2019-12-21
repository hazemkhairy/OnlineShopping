namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingPaymentType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTypes");
        }
    }
}
