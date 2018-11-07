namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeLeaves", "StartDate", c => c.DateTime());
            AlterColumn("dbo.EmployeeLeaves", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeLeaves", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeLeaves", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
