namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelAll1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Level");
        }
    }
}
