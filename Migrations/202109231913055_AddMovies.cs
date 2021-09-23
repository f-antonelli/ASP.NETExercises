namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (1, 'Hangover', 4, '2001-04-13', '1998-04-15', 2)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (2, 'Shrek', 2, 2015-04-25, 2003-01-03, 1)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (3, 'Toy Story', 1, 2012-01-29, 2000-10-23, 5)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (4, 'Titanic', 3, 2013-07-02, 1999-11-21, 7)");
            Sql("INSERT INTO Movies (Id, Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES (5, 'Popeye', 4, 2016-12-09, 1990-05-11, 3)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }

        public override void Down()
        {
        }
    }
}
