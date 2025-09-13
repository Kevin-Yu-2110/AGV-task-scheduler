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
    internal class AssignTaskWindowService : IWindowService<AssignTaskViewModel>
    {
        public AssignTaskView CurrentAssignTaskView { get; set; }
        public void OpenWindow(AssignTaskViewModel assignTaskViewModel)
        {
            var assignTaskView = new AssignTaskView()
            {
                DataContext = assignTaskViewModel,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            CurrentAssignTaskView = assignTaskView;
            assignTaskView.ShowDialog();
        }
        public void CloseWindow()
        {
            CurrentAssignTaskView.Close();
        }
    }
}
