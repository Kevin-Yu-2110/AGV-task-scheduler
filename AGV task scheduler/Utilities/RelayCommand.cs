using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AGV_task_scheduler.Utilities
{
    internal class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute=null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object obj)
        {
            if (obj == null) return true;
            return _canExecute.Invoke(obj);
        }
        public void Execute(object obj)
        {
            _execute.Invoke(obj);
        }
        public void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }
    }
}
