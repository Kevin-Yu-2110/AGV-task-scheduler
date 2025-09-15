using AGV_task_scheduler.domain.Commands;
using Models = AGV_task_scheduler.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using AGV_task_scheduler.domain.Models;

namespace AGV_task_scheduler.infrastructure.Commands
{
    public class LogTaskRunCommand : ILogTaskRunCommand
    {
        private readonly AGVTaskSchedulerDbContextFactory _dbContextFactory;
        public LogTaskRunCommand(AGVTaskSchedulerDbContextFactory dbContextFactory)
        {
            _dbContextFactory  = dbContextFactory;
        }
        public async Tasks.Task Execute(TaskRun taskRun)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.TaskRuns.Add(taskRun);
                await context.SaveChangesAsync();
            }
        }
    }
}
