namespace DoctorsAppoinmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorAndDepartment2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DoctorModels", "Department_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DoctorModels", "Department_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Departments", "Id", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
