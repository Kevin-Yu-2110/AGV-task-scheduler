using AGV_task_scheduler.domain.Commands;
using AGV_task_scheduler.Services;
using AGV_task_scheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AGV_task_scheduler.ViewModels
{
    internal class DashboardViewModel : ViewModelBase
    {
        private readonly IWindowService<TasksRunViewModel> _tasksRunWindowService;
        public ICommand OpenTasksRunViewCommand {  get; set; }
        public AGVPanelViewModel AGVPanelViewModel { get; }
        public TasksPanelViewModel TaskPanelViewModel { get; }
        public DashboardViewModel(Stores.AGVStore aGVStore, ILogTaskRunCommand logTaskRunCommand, IGetAllTaskRunsCommand getAllTaskRunsCommand)
        {
            AGVPanelViewModel = new AGVPanelViewModel(aGVStore);
            TaskPanelViewModel = new TasksPanelViewModel(aGVStore, logTaskRunCommand);
            _tasksRunWindowService = new TasksRunWindowService();
            OpenTasksRunViewCommand = new RelayCommand(
                execute: async _ => _tasksRunWindowService.OpenWindow(await TasksRunViewModel.BuildTaskRunViewModelAsync(getAllTaskRunsCommand)));
        }
    }
}
