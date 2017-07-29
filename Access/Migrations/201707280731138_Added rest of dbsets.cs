namespace Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrestofdbsets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Review = c.String(),
                        StoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.StoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        MaxUsers = c.Int(nullable: false),
                        HasRudewords = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        GenreId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.StoryParts",
                c => new
                    {
                        StoryPartId = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Content = c.String(),
                        StoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoryPartId)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.StoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Forename = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CurrentScore = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryParts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.StoryParts", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Ratings", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Stories", "GenreId", "dbo.Genres");
            DropIndex("dbo.StoryParts", new[] { "UserId" });
            DropIndex("dbo.StoryParts", new[] { "StoryId" });
            DropIndex("dbo.Stories", new[] { "GenreId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "StoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.StoryParts");
            DropTable("dbo.Stories");
            DropTable("dbo.Ratings");
        }
    }
}
