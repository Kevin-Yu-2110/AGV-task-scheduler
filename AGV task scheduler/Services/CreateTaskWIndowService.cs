using AGV_task_scheduler.Components;
using AGV_task_scheduler.Models;
using AGV_task_scheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace AGV_task_scheduler.Services
{
    internal class CreateTaskWindowService : IWindowService
    {
        private readonly ObservableCollection<Task> _tasks;

        public CreateTaskWindowService(ObservableCollection<Task> tasks)
        {
            _tasks = tasks;
        }
        public void OpenWindow()
        {
            var createTaskView = new CreateTaskView()
            {

                DataContext = new CreateTaskViewModel(_tasks),
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner

            };
            createTaskView.ShowDialog();
        }
        public void CloseWindow() { }
    }
}
