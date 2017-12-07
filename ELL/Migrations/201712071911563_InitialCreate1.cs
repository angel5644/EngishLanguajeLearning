namespace ELL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parent", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Parent", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Parent", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Payment", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            AlterColumn("dbo.Payment", "Description", c => c.String());
            AlterColumn("dbo.Parent", "Phone", c => c.String());
            AlterColumn("dbo.Parent", "LastName", c => c.String());
            AlterColumn("dbo.Parent", "FirstName", c => c.String());
        }
    }
}
