namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formulae",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, unicode: false),
                    Descriprion = c.String(nullable: false, unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);

            CreateTable(
                "dbo.Lemmata",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, unicode: false),
                    Descriprion = c.String(nullable: false, unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);

            CreateTable(
                "dbo.Professors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, unicode: false),
                    Descriprion = c.String(nullable: false, unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);

            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, unicode: false),
                    Descriprion = c.String(nullable: false, unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);

            CreateTable(
                "dbo.Theorems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, unicode: false),
                    Descriprion = c.String(nullable: false, unicode: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId);
            
            AddColumn("dbo.Disciplines", "Description", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.Disciplines", "Desciption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disciplines", "Desciption", c => c.String(nullable: false, unicode: false));
            DropForeignKey("dbo.Theorems", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Tasks", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Professors", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Lemmata", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Formulae", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Axioms", "TopicId", "dbo.Topics");
            DropIndex("dbo.Theorems", new[] { "TopicId" });
            DropIndex("dbo.Tasks", new[] { "TopicId" });
            DropIndex("dbo.Professors", new[] { "TopicId" });
            DropIndex("dbo.Lemmata", new[] { "TopicId" });
            DropIndex("dbo.Formulae", new[] { "TopicId" });
            DropIndex("dbo.Axioms", new[] { "TopicId" });
            DropColumn("dbo.Disciplines", "Description");
            DropTable("dbo.Theorems");
            DropTable("dbo.Tasks");
            DropTable("dbo.Professors");
            DropTable("dbo.Lemmata");
            DropTable("dbo.Formulae");
            DropTable("dbo.Axioms");
        }
    }
}
