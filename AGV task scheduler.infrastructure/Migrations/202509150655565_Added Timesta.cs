namespace AGV_task_scheduler.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimesta : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TaskDTOes", newName: "TaskRuns");
            AddColumn("dbo.TaskRuns", "CompleteTimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskRuns", "CompleteTimeStamp");
            RenameTable(name: "dbo.TaskRuns", newName: "TaskDTOes");
        }
    }
}
