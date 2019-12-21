namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingPaymentType2 : DbMigration
    {
        public override void Up()
        {

            Sql("Insert into Categories (Name) Values('Cash')");
            Sql("Insert into Categories (Name) Values('Visa')"); 
            Sql("Insert into Categories (Name) Values('PayPal')");
        }
        
        public override void Down()
        {
        }
    }
}
