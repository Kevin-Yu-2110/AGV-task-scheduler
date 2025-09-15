using AGV_task_scheduler.domain.Commands;
using AGV_task_scheduler.domain.Models;
using AGV_task_scheduler.infrastructure.Commands;
using AGV_task_scheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;

namespace AGV_task_scheduler.ViewModels
{
    internal class TasksRunViewModel : ViewModelBase
    {
        public ObservableCollection<TaskRun> TaskRuns { get; private set; }
        
        async public static Task<TasksRunViewModel> BuildTaskRunViewModelAsync(IGetAllTaskRunsCommand getAllTaskRunsCommand)
        {
            var collection = await getAllTaskRunsCommand.Execute();
            var tmp = new ObservableCollection<TaskRun>(collection);
            return new TasksRunViewModel(tmp);
        }
        private TasksRunViewModel(ObservableCollection<TaskRun> taskRuns)
        {
            TaskRuns = taskRuns;
        }
    }
}
