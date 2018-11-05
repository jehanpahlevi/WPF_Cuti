namespace CutiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Companies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Companies_Id)
                .Index(t => t.Companies_Id);
            
            CreateTable(
                "dbo.EmployeeLeaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        TotalDays = c.Int(nullable: false),
                        Backup = c.String(),
                        Note = c.String(),
                        Status = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                        Leaves_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.Leaves", t => t.Leaves_Id)
                .Index(t => t.Employees_Id)
                .Index(t => t.Leaves_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Telp = c.String(),
                        JobTitle = c.String(),
                        Status = c.String(),
                        TotalChilds = c.Int(nullable: false),
                        Password = c.String(),
                        ThisYearBalance = c.Int(nullable: false),
                        LastYearBalance = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Departments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .Index(t => t.Departments_Id);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveType = c.String(),
                        LengthDays = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Activity = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.Employees_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLogs", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeLeaves", "Leaves_Id", "dbo.Leaves");
            DropForeignKey("dbo.EmployeeLeaves", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Companies_Id", "dbo.Companies");
            DropIndex("dbo.UserLogs", new[] { "Employees_Id" });
            DropIndex("dbo.Employees", new[] { "Departments_Id" });
            DropIndex("dbo.EmployeeLeaves", new[] { "Leaves_Id" });
            DropIndex("dbo.EmployeeLeaves", new[] { "Employees_Id" });
            DropIndex("dbo.Departments", new[] { "Companies_Id" });
            DropTable("dbo.UserLogs");
            DropTable("dbo.Leaves");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeLeaves");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
        }
    }
}
