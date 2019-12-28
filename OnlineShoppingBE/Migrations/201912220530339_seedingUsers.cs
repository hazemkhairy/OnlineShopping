namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Users (FirstName,LastName,Email,Password,IsAdmin) " +
                "Values('hazem','khairry','admin@yahoo.com','123',1)");
        }
        
        public override void Down()
        {
        }
    }
}
