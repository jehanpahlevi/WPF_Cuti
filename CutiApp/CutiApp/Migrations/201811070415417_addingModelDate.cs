namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeLeaves", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeLeaves", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeLeaves", "EndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.EmployeeLeaves", "StartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
