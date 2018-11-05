namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Name", c => c.String());
            AddColumn("dbo.Departments", "ManagerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "ManagerId");
            DropColumn("dbo.Departments", "Name");
        }
    }
}
