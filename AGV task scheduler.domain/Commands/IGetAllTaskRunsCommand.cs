using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.domain.Commands
{
    public interface IGetAllTaskRunsCommand
    {
        Task<IEnumerable<Models.TaskRun>> Execute();
    }
}
