namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imagees : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.String(unicode: false));
            AlterColumn("dbo.Tasks", "Descriprion", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Descriprion", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false, unicode: false));
        }
    }
}
