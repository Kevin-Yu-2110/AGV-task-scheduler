using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.Models
{
    public enum Status
    {
        Idle,
        InTransit,
        Failed,
        Charging
    }
    internal class AGV
    {
        public int ID { get; }
        public Task Task { get; }
        public Status Status { get; }

        public AGV(int id, Task task, Status status)
        {
            ID = id;
            Task = task;
            Status = status;
        }
    }
}
