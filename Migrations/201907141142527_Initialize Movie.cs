namespace VideoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Hangover','19900305','20190712',10,1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Hangover2','19990305','20190712',10,1)");
        }
        
        public override void Down()
        {
        }
    }
}
