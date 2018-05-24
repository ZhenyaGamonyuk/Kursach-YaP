namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Axiom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Axioms",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, unicode: false),
                    Descriprion = c.String(nullable: false, unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Axioms", "TopicId", "dbo.Topics");
            DropIndex("dbo.Axioms", new[] { "TopicId" });
            DropTable("dbo.Axioms");
        }
    }
}
