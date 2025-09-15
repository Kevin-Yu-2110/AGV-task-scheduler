using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using AGV_task_scheduler.domain.Models;
using AGV_task_scheduler.domain.Commands;
using System.Data.Entity;

namespace AGV_task_scheduler.infrastructure.Commands
{
    public class GetAllTaskRunsCommand : IGetAllTaskRunsCommand
    {
        private readonly AGVTaskSchedulerDbContextFactory _dbFactory;
        public GetAllTaskRunsCommand(AGVTaskSchedulerDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public async Tasks.Task<IEnumerable<TaskRun>> Execute()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var taskRuns = await context.TaskRuns.ToListAsync();
                return taskRuns;
            }
        }
    }
}
