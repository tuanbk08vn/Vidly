namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerViewModels", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.MovieViewModels", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.CustomerViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Birthdate = c.DateTime(),
                        IsSubsriberdToNewsLetter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MovieViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GenreId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(),
                        DateAdded = c.DateTime(),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.MovieViewModels");
            DropForeignKey("dbo.MovieViewModels", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.CustomerViewModels");
            DropForeignKey("dbo.CustomerViewModels", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.MovieViewModels", new[] { "GenreId" });
            DropIndex("dbo.CustomerViewModels", new[] { "MembershipTypeId" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropTable("dbo.MovieViewModels");
            DropTable("dbo.CustomerViewModels");
            DropTable("dbo.Rentals");
        }
    }
}
