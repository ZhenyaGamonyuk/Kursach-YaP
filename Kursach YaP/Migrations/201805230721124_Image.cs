namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Formulae", "ImageData", c => c.Binary());
            AddColumn("dbo.Formulae", "ImageMimeType", c => c.String(unicode: false));
            AlterColumn("dbo.Formulae", "Name", c => c.String(unicode: false));
            AlterColumn("dbo.Formulae", "Descriprion", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Formulae", "Descriprion", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Formulae", "Name", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.Formulae", "ImageMimeType");
            DropColumn("dbo.Formulae", "ImageData");
        }
    }
}
