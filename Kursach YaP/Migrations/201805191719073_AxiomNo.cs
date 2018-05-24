namespace Kursach_YaP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AxiomNo : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Axioms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Axioms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Descriprion = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
