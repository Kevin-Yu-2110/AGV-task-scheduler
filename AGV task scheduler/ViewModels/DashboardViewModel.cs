using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {
        public AGVPanelViewModel AGVPanelViewModel { get; }
        public TasksPanelViewModel TaskPanelViewModel { get; }
        public DashboardViewModel(Stores.AGVStore aGVStore)
        {
            AGVPanelViewModel = new AGVPanelViewModel(aGVStore);
            TaskPanelViewModel = new TasksPanelViewModel(aGVStore);
        }
    }
}
