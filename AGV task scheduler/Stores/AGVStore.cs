using AGV_task_scheduler.domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.Stores
{
    internal class AGVStore
    {
        public ObservableCollection<AGV> AGVs { get; }

        public AGVStore()
        {
            AGVs = new ObservableCollection<AGV>();
        }
    }
}
