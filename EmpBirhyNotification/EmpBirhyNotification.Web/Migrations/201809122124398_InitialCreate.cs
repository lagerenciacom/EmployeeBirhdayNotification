namespace EmpBirhyNotification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        Address = c.String(),
                        HireDate = c.DateTime(),
                        Email = c.String(maxLength: 25),
                        Tel = c.Int(),
                        Cel = c.Int(),
                        Password = c.String(),
                        PictureRoute = c.String(),
                        GenderrId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Gender_GenderId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.Gender_GenderId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.Email, unique: true, name: "Employee_Email_Index")
                .Index(t => t.DepartmentId)
                .Index(t => t.StatusId)
                .Index(t => t.Gender_GenderId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Employees", "Gender_GenderId", "dbo.Genders");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Gender_GenderId" });
            DropIndex("dbo.Employees", new[] { "StatusId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", "Employee_Email_Index");
            DropTable("dbo.Status");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Genders");
        }
    }
}
