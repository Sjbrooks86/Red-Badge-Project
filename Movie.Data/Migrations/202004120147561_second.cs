namespace Movie.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flix", "MovieGenre", c => c.String());
            AddColumn("dbo.Flix", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Flix", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Flix", "MovieGrenre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flix", "MovieGrenre", c => c.String());
            DropColumn("dbo.Flix", "ModifiedUtc");
            DropColumn("dbo.Flix", "CreatedUtc");
            DropColumn("dbo.Flix", "MovieGenre");
        }
    }
}
