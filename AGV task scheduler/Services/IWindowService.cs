using AGV_task_scheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_task_scheduler.Services
{
    internal interface IWindowService<TViewModel> where TViewModel : ViewModelBase
    {
        void OpenWindow(TViewModel viewModel);
        void CloseWindow();
    }
}
