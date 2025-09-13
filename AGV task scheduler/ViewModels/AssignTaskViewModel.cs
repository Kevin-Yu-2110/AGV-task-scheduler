using AGV_task_scheduler.Models;
using AGV_task_scheduler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AGV_task_scheduler.ViewModels
{
    internal class AssignTaskViewModel : ViewModelBase
    {
        public ObservableCollection<AGV> AvailableAGVs { get; }
        public AGV SelectedAGV { get; set; }
        public ICommand AssignAGVCommand { get; set; }
        public Action CloseAction { get; set; }
        public AssignTaskViewModel(ObservableCollection<AGV> aGVStore, Task selectedTask)
        {
            //because available agvs is a copy, it will not update
            //agvs that become available while the window is open wont dynamically appear
            AvailableAGVs = new ObservableCollection<AGV>(aGVStore.Where(aGV => aGV.CurrentStatus == AGV.Status.Idle));
            AssignAGVCommand = new RelayCommand(
                execute: _ =>
                {
                    if (SelectedAGV != null)
                    {
                        selectedTask.MarkInProgress(SelectedAGV.Id);
                        SelectedAGV.AssignTask(selectedTask);
                        CloseAction.Invoke();
                    }
                }
            );
        }
    }
}
