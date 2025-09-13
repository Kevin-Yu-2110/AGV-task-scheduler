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
