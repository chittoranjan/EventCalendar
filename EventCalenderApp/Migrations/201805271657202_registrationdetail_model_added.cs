namespace EventCalenderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registrationdetail_model_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegistrationDetails");
        }
    }
}
