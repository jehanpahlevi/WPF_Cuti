namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelManagerID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "ManagerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "ManagerId", c => c.String());
        }
    }
}
