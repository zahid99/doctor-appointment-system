namespace DoctorsAppoinmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorAndDepartments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BMDCRegNo = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(),
                        Department_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorModels", "Department_Id", "dbo.Departments");
            DropIndex("dbo.DoctorModels", new[] { "Department_Id" });
            DropTable("dbo.DoctorModels");
            DropTable("dbo.Departments");
        }
    }
}
