namespace Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keywordTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeywordTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Keywords", "KeywordTypeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Keywords", "KeywordTypeId");
            AddForeignKey("dbo.Keywords", "KeywordTypeId", "dbo.KeywordTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keywords", "KeywordTypeId", "dbo.KeywordTypes");
            DropIndex("dbo.Keywords", new[] { "KeywordTypeId" });
            DropColumn("dbo.Keywords", "KeywordTypeId");
            DropTable("dbo.KeywordTypes");
        }
    }
}
