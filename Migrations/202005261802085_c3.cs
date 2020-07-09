namespace mvcproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.employees", "name", c => c.String(maxLength: 50));
            AlterColumn("dbo.employees", "password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.employees", "password", c => c.String(nullable: false));
            AlterColumn("dbo.employees", "name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
