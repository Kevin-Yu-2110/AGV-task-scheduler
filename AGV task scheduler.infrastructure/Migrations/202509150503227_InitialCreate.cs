namespace AGV_task_scheduler.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskDescription = c.String(),
                        AssignedAGVId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskDTOes");
        }
    }
}
