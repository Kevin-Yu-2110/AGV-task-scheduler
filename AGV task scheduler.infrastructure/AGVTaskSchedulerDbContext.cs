using AGV_task_scheduler.domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AGV_task_scheduler.infrastructure
{
    public class AGVTaskSchedulerDbContext : DbContext
    {
        public DbSet<TaskRun> TaskRuns { get; set; }
        public AGVTaskSchedulerDbContext(string connectionString) : base(connectionString) { }
        public AGVTaskSchedulerDbContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;Database=AGVDatabase;Integrated Security=True;") { }
    }
}
