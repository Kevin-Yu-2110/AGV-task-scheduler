using AGV_task_scheduler.Components;
using AGV_task_scheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AGV_task_scheduler.Services
{
    internal class TasksRunWindowService : IWindowService<TasksRunViewModel>
    {
       public void OpenWindow(TasksRunViewModel tasksRunViewModel)
        {
            var tasksRunView = new TasksRunView()
            {
                DataContext = tasksRunViewModel,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            tasksRunView.ShowDialog();
        }
        public void CloseWindow() { }
    }
}
