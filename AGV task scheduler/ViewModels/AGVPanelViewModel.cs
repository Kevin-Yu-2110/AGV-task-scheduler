using AGV_task_scheduler.Models;
using AGV_task_scheduler.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AGV_task_scheduler.Utilities;

namespace AGV_task_scheduler.ViewModels
{
    internal class AGVPanelViewModel : ViewModelBase
    {
        private readonly AGVStore _store;
        public ICommand AddAGVCommand { get; }
        public ICommand RemoveAGVCommand { get; }
        public ObservableCollection<AGV> Store
        {
            get { return _store.AGVs; }
        }
        public AGVPanelViewModel(AGVStore store)
        {
            _store = store;
            AddAGVCommand = new RelayCommand(
                execute: _ => Store.Add(new AGV(Status.Idle))
            );
        }


    }
}
