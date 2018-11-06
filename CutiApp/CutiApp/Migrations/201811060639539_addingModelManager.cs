namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ManagerId", c => c.String());
            DropColumn("dbo.Departments", "ManagerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "ManagerId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "ManagerId");
        }
    }
}
