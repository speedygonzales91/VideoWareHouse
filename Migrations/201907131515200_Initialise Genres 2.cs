namespace VideoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialiseGenres2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
