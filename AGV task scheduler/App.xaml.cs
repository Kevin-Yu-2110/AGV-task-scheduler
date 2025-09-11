using AGV_task_scheduler.Stores;
using AGV_task_scheduler.ViewModels;
using System.Windows;

namespace AGV_task_scheduler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AGVStore _AGVStore;
        public App()
        {
            _AGVStore = new AGVStore();
            _AGVStore.AGVs.Add(new Models.AGV(0, new Models.Task(), Models.Status.Idle));
            _AGVStore.AGVs.Add(new Models.AGV(1, new Models.Task(), Models.Status.Idle));
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new DashboardViewModel(_AGVStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
