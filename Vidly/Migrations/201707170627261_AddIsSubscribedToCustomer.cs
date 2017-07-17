namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubsriberdToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubsriberdToNewsLetter");
        }
    }
}