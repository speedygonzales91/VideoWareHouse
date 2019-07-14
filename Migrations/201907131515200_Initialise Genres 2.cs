namespace VideoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialiseGenres2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
