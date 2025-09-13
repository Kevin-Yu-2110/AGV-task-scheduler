using AGV_task_scheduler.Models;
using AGV_task_scheduler.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Input;
using AGV_task_scheduler.Utilities;
using AGV_task_scheduler.Services;

namespace AGV_task_scheduler.ViewModels
{
    internal class TasksPanelViewModel : ViewModelBase
    {
        private readonly AGVStore _store;
        private readonly IWindowService _createTaskWindowService;
        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();
        public CreateTaskViewModel CreateTaskViewModel { get; }
        public ICommand OpenCreateTaskWindowCommand { get; }
        public ICommand AssignTaskCommand { get; }
        public ObservableCollection<AGV> AGVStore
        {
            get { return _store.AGVs; }
        }
        public TasksPanelViewModel(AGVStore aGVStore)
        {
            _store = aGVStore;
            _createTaskWindowService = new CreateTaskWindowService(Tasks);
            OpenCreateTaskWindowCommand = new RelayCommand(
                execute: _ => _createTaskWindowService.OpenWindow()
            );
        }
    }
}
