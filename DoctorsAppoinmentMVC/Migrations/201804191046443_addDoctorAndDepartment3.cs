namespace DoctorsAppoinmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorAndDepartment3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorModels", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.DoctorModels", "HospitalId", c => c.Int(nullable: false));
            AddColumn("dbo.DoctorModels", "Fees", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorModels", "Fees");
            DropColumn("dbo.DoctorModels", "HospitalId");
            DropColumn("dbo.DoctorModels", "LocationId");
        }
    }
}
