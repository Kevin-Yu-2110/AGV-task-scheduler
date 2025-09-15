using AGV_task_scheduler.domain.Models;
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
using System.Security.Permissions;
using AGV_task_scheduler.domain.Commands;

namespace AGV_task_scheduler.ViewModels
{
    internal class TasksPanelViewModel : ViewModelBase
    {
        private readonly AGVStore _store;
        private readonly IWindowService<CreateTaskViewModel> _createTaskWindowService;
        private readonly IWindowService<AssignTaskViewModel> _assignTaskWindowService;
        private readonly ILogTaskRunCommand _logTaskRunCommand;
        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();
        public CreateTaskViewModel CreateTaskViewModel { get; }
        public Task SelectedTask { get; set; }
        public ICommand OpenCreateTaskWindowCommand { get; }
        public ICommand OpenAssignTaskWindowCommand { get; }
        public ObservableCollection<AGV> AGVStore
        {
            get { return _store.AGVs; }
        }
        public TasksPanelViewModel(AGVStore aGVStore, ILogTaskRunCommand logTaskRunCommand)
        {
            _store = aGVStore;
            _logTaskRunCommand = logTaskRunCommand;
            _createTaskWindowService = new CreateTaskWindowService();
            _assignTaskWindowService = new AssignTaskWindowService();
            OpenCreateTaskWindowCommand = new RelayCommand(
                execute: _ => _createTaskWindowService.OpenWindow(new CreateTaskViewModel(Tasks))
            );
            OpenAssignTaskWindowCommand = new RelayCommand(
                execute: _ =>
                {
                    if (SelectedTask == null || SelectedTask.CurrentStatus == Task.Status.Complete) return;
                    var assignTaskViewModel = new AssignTaskViewModel(AGVStore, SelectedTask, logTaskRunCommand)
                    {
                        CloseAction = _assignTaskWindowService.CloseWindow
                    };
                    _assignTaskWindowService.OpenWindow(assignTaskViewModel);
                }
            );
        }
    }
}
