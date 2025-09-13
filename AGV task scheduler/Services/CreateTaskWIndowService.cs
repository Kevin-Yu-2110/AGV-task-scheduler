using AGV_task_scheduler.Components;
using AGV_task_scheduler.Models;
using AGV_task_scheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AGV_task_scheduler.Services
{
    internal class CreateTaskWindowService : IWindowService<CreateTaskViewModel>
    {
        public void OpenWindow(CreateTaskViewModel createTaskViewModel)
        {
            var createTaskView = new CreateTaskView()
            {
                DataContext = createTaskViewModel,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            createTaskView.ShowDialog();
        }
        public void CloseWindow() { }
    }
}
