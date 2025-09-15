using AGV_task_scheduler.domain.Commands;
using AGV_task_scheduler.infrastructure;
using AGV_task_scheduler.infrastructure.Commands;
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
        private readonly AGVTaskSchedulerDbContextFactory _aGVTaskSchedulerDbContextFactory;
        public App()
        {
            _AGVStore = new AGVStore();
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=AGVDatabase;Integrated Security=True;";
            _aGVTaskSchedulerDbContextFactory = new AGVTaskSchedulerDbContextFactory(connectionString);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new DashboardViewModel(_AGVStore, new LogTaskRunCommand(_aGVTaskSchedulerDbContextFactory), new GetAllTaskRunsCommand(_aGVTaskSchedulerDbContextFactory))
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
