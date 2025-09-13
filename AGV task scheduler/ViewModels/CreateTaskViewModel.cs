using AGV_task_scheduler.Models;
using AGV_task_scheduler.Services;
using AGV_task_scheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AGV_task_scheduler.ViewModels
{
    internal class CreateTaskViewModel : ViewModelBase
    {
        private string _taskDescription;
        public ICommand AddTaskCommand { get; }
        public string TaskDescription
        {
            get => _taskDescription;
            set
            {
                if (value == _taskDescription) return;
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }
        public CreateTaskViewModel(ObservableCollection<Task> tasks)
        {
            AddTaskCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_taskDescription != "")
                    {
                        tasks.Add(new Task(TaskDescription));
                        TaskDescription = "";
                    }
                }
            );
        }
    }
}
