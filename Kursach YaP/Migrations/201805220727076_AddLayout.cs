namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLayout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Axioms", "Layout", c => c.Int(nullable: false));
            AddColumn("dbo.Formulae", "Layout", c => c.Int(nullable: false));
            AddColumn("dbo.Lemmata", "Layout", c => c.Int(nullable: false));
            AddColumn("dbo.Professors", "Layout", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Layout", c => c.Int(nullable: false));
            AddColumn("dbo.Theorems", "Layout", c => c.Int(nullable: false));
            AddColumn("dbo.Texts", "Layout", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Texts", "Layout");
            DropColumn("dbo.Theorems", "Layout");
            DropColumn("dbo.Tasks", "Layout");
            DropColumn("dbo.Professors", "Layout");
            DropColumn("dbo.Lemmata", "Layout");
            DropColumn("dbo.Formulae", "Layout");
            DropColumn("dbo.Axioms", "Layout");
        }
    }
}
