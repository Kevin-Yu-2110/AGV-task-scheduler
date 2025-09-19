using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.domain.Models
{
    public class TaskRun
    {
        public int Id { get; set; }
        public int? AssignedAGVId {  get; set; }
        public DateTime CompletedTimeStamp {  get; set; }
        public string TaskDescription { get; set; }
    }
}
