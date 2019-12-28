namespace OnlineShoppingBE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Users (FirstName,LastName,Email,Password,IsAdmin) " +
                "Values('admin','hazem','admin@gmail.com','123',1)"); 
            Sql("Insert Into Users (FirstName,LastName,Email,Password,IsAdmin) " +
                 "Values('user','hazem','user@gmail.com','123',0)");
        }
        
        public override void Down()
        {
        }
    }
}
