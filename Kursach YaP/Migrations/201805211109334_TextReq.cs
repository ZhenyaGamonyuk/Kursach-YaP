namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Texts", "Title", c => c.String(unicode: false));
            AlterColumn("dbo.Texts", "Plot", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Texts", "Plot", c => c.String(unicode: false));
            AlterColumn("dbo.Texts", "Title", c => c.String(nullable: false, unicode: false));
        }
    }
}
