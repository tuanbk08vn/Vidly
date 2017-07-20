namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCustomerBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(Name,IsSubsriberdToNewsLetter,MembershipTypeId,Birthdate) VALUES('Will Smith',0,1,1990/11/09)");
            Sql("INSERT INTO Customers(Name,IsSubsriberdToNewsLetter,MembershipTypeId,Birthdate) VALUES('Jame Comey',1,2,1993/18/05)");
        }

        public override void Down()
        {
        }
    }
}
