namespace Movie.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTableNotDropped_TryingToFix : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Movie");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                {
                    MovieId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    MovieImage = c.String(),
                    MovieName = c.String(),
                    MovieGrenre = c.String(),
                    MovieDescription = c.String(),
                    MovieRating = c.String(),
                    MovieCast = c.String(),
                })
                .PrimaryKey(t => t.MovieId);
        }
    }
}
