namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePaymentTypeAndCategories : DbMigration
    {
        public override void Up()
        {
            Sql("Delete From Categories ");

            Sql("Insert into Categories (Name) Values('Fruits')");
            Sql("Insert into Categories (Name) Values('Vegtables')");
            Sql("Insert into Categories (Name) Values('Electronics')");

            Sql("Insert into PaymentTypes (Name) Values('Cash')");
            Sql("Insert into PaymentTypes (Name) Values('Visa')");
            Sql("Insert into PaymentTypes (Name) Values('PayPal')");
        }
        
        public override void Down()
        {
        }
    }
}
