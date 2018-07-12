namespace DoctorsAppoinmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DoctorModels", "Area_Id", c => c.Int());
            CreateIndex("dbo.DoctorModels", "Area_Id");
            AddForeignKey("dbo.DoctorModels", "Area_Id", "dbo.Areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorModels", "Area_Id", "dbo.Areas");
            DropIndex("dbo.DoctorModels", new[] { "Area_Id" });
            DropColumn("dbo.DoctorModels", "Area_Id");
            DropTable("dbo.Areas");
        }
    }
}
