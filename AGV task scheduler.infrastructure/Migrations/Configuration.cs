namespace AGV_task_scheduler.infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AGV_task_scheduler.infrastructure.AGVTaskSchedulerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AGV_task_scheduler.infrastructure.AGVTaskSchedulerDbContext";
        }

        protected override void Seed(AGV_task_scheduler.infrastructure.AGVTaskSchedulerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
