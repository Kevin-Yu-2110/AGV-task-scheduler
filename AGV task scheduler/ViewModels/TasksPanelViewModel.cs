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

namespace AGV_task_scheduler.ViewModels
{
    internal class TasksPanelViewModel : ViewModelBase
    {
        private readonly AGVStore _store;
        public ObservableCollection<Task> Tasks { get; }
        public ICommand GetTask { get; }
        public ICommand AssignTask { get; }
        public ObservableCollection<AGV> AGVStore
        {
            get { return _store.AGVs; }
        }
        public TasksPanelViewModel(Stores.AGVStore aGVStore)
        {
            _store = aGVStore;
            Tasks = new ObservableCollection<Task>()
            {
                new Task()
            };

        }
    }
}
