namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class GenreMovieAdding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Movies",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GenreId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);

            CreateTable(
                    "dbo.Genres",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Genres(Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES('Action')");
            Sql("INSERT INTO Genres(Name) VALUES('Romantic')");
            Sql("INSERT INTO Genres(Name) VALUES('Family')");

            Sql("INSERT INTO Movies(Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Hangover',1,2012/02/05,2012/03/08,5)");
            Sql("INSERT INTO Movies(Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Die Hard',2,2013/05/05,2013/05/08,5)");
            Sql("INSERT INTO Movies(Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('The Terminator',2,2010/03/05,2010/03/06,5)");
            Sql("INSERT INTO Movies(Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Toy Story',4,1998/12/05,1998/07/08,5)");
            Sql("INSERT INTO Movies(Name,GenreId,ReleaseDate,DateAdded,NumberInStock) VALUES('Titanic',3,2013/11/05,2013/06/08,5)");
        }

        public override void Down()
        {


            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");

        }
    }
}
