namespace AGV_task_scheduler.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Taskrun : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskRuns", "CompletedTimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.TaskRuns", "CompleteTimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskRuns", "CompleteTimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.TaskRuns", "CompletedTimeStamp");
        }
    }
}
