namespace EmpBirhyNotification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModsOnView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Discriminator");
        }
    }
}
