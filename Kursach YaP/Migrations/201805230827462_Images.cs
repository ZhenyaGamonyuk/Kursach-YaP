namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professors", "ImageData", c => c.Binary());
            AddColumn("dbo.Professors", "ImageMimeType", c => c.String(unicode: false));
            AddColumn("dbo.Tasks", "ImageData", c => c.Binary());
            AddColumn("dbo.Tasks", "ImageMimeType", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "ImageMimeType");
            DropColumn("dbo.Tasks", "ImageData");
            DropColumn("dbo.Professors", "ImageMimeType");
            DropColumn("dbo.Professors", "ImageData");
        }
    }
}
