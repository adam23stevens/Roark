namespace Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keywordandgenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        GenreId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keywords", "GenreId", "dbo.Genres");
            DropIndex("dbo.Keywords", new[] { "GenreId" });
            DropTable("dbo.Keywords");
            DropTable("dbo.Genres");
        }
    }
}
