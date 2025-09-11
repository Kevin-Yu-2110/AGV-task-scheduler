using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.Models
{
    internal class Task
    {
        public string TaskDescription { get; }

        public Task()
        {
            TaskDescription = "dummy description";
        }
    }
}
