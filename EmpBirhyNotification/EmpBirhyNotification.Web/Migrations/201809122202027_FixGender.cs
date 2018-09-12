namespace EmpBirhyNotification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixGender : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Gender_GenderId", "dbo.Genders");
            DropIndex("dbo.Employees", new[] { "Gender_GenderId" });
            RenameColumn(table: "dbo.Employees", name: "Gender_GenderId", newName: "GenderId");
            AlterColumn("dbo.Employees", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "GenderId");
            AddForeignKey("dbo.Employees", "GenderId", "dbo.Genders", "GenderId", cascadeDelete: true);
            DropColumn("dbo.Employees", "GenderrId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "GenderrId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropIndex("dbo.Employees", new[] { "GenderId" });
            AlterColumn("dbo.Employees", "GenderId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "GenderId", newName: "Gender_GenderId");
            CreateIndex("dbo.Employees", "Gender_GenderId");
            AddForeignKey("dbo.Employees", "Gender_GenderId", "dbo.Genders", "GenderId");
        }
    }
}
