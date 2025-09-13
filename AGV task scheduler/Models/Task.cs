using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AGV_task_scheduler.Models
{
    internal class Task
    {
        public string TaskDescription { get; }
        public AGV AssignedAGV { get; set; }
        public Task(string description, AGV assignedAGV=null)
        {
            TaskDescription = description;
            AssignedAGV = assignedAGV;
        }
    }
}
