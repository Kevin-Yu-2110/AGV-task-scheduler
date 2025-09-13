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
        private static int _nextId = 0; //not type safe but only one thread adding agvs in this program
        public int Id { get; }
        public Task Task { get; }
        public Status Status { get; }

        public AGV(Status status, Task task=null)
        {
            Id = _nextId;
            _nextId++;
            Task = task;
            Status = status;
        }
    }
}
