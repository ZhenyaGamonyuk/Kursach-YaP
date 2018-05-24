namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddText1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Texts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, unicode: false),
                    Plot = c.String(unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Texts", "TopicId", "dbo.Topics");
            DropIndex("dbo.Texts", new[] { "TopicId" });
            DropTable("dbo.Texts");
        }
    }
}
