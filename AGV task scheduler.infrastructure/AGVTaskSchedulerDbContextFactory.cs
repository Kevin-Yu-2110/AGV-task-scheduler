using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.infrastructure
{
    public class AGVTaskSchedulerDbContextFactory
    {
        private readonly string _connectionString;
        public AGVTaskSchedulerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AGVTaskSchedulerDbContext CreateDbContext()
        {
            return new AGVTaskSchedulerDbContext(_connectionString);
        }
    }
}
