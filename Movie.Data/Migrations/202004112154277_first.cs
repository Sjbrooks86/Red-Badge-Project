namespace Movie.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flix",
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
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Flix");
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
