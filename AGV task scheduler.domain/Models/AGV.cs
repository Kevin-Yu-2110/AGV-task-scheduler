using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemTasks = System.Threading.Tasks;
using System.ComponentModel;
using System.Security;
using AGV_task_scheduler.domain.Commands;

namespace AGV_task_scheduler.domain.Models
{
    public class AGV : INotifyPropertyChanged
    {
        public enum Status
        {
            Idle,
            Processing,
            Failed,
            Charging
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private Status _currentStatus = Status.Idle;

        private static int _nextId = 0; //not type safe but only one thread adding agvs in this program
        public int Id { get; }
        public Task AssignedTask { get; private set; }
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
        public AGV()
        {
            Id = _nextId;
            _nextId++;

        }
        public bool AssignTask(Task task, ILogTaskRunCommand logTaskRunCommand)
        {
            if (CurrentStatus != Status.Idle)
            {
                return false;
            }
            AssignedTask = task;
            CurrentStatus = Status.Processing;
            ProcessTask(logTaskRunCommand);
            return true;
        }
        public async SystemTasks.Task<bool> ProcessTask(ILogTaskRunCommand logTaskRunCommand) //only returns true now since i haven't implemented failing
        {
            var rnd = new Random();
            var delay = rnd.Next(1000, 20001);
            await SystemTasks.Task.Delay(delay);
            AssignedTask.MarkComplete();
            CurrentStatus = Status.Idle;
            await logTaskRunCommand.Execute(new TaskRun()
            {
                TaskDescription = AssignedTask.TaskDescription,
                AssignedAGVId = AssignedTask.AssignedAGVId,
                CompletedTimeStamp = DateTime.Now,
            });
            return true;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
