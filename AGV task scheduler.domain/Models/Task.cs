using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AGV_task_scheduler.domain.Models
{
    public class Task : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public enum Status
        {
            Pending,
            InProgress,
            Complete,
        }
        private int? _assignedAGVId = null;
        private Status _currentStatus;
        public string TaskDescription { get; }
        public int? AssignedAGVId
        {
            get { return _assignedAGVId; }
            set
            {
                if (_assignedAGVId == value) return;
                _assignedAGVId = value;
                OnPropertyChanged(nameof(AssignedAGVId));
            }
        }
        public Status CurrentStatus
        {
            get { return _currentStatus; }
            private set
            {
                if (_currentStatus == value) return;
                _currentStatus = value;
                OnPropertyChanged(nameof(CurrentStatus));
            }
        }
        public Task(string description)
        {
            TaskDescription = description;
            CurrentStatus = Status.Pending;
        }
        public bool MarkInProgress(int agvId)
        {
            if (CurrentStatus != Status.Pending)
            {
                return false;
            }
            AssignedAGVId = agvId;
            CurrentStatus = Status.InProgress;
            return true;
        }
        public bool MarkComplete()
        {
            if (CurrentStatus != Status.InProgress)
            {
                return false;
            }
            CurrentStatus = Status.Complete;
            return true;
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
