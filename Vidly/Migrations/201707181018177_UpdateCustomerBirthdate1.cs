namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateCustomerBirthdate1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '11/09/1990' WHERE Id=1");
            Sql("UPDATE Customers SET Birthdate = '05/10/1993' WHERE Id=2");
        }

        public override void Down()
        {
        }
    }
}