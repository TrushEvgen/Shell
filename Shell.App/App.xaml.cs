using Shell.App.ViewModels;
using Shell.App.Views;
using System.Windows;

namespace Shell.App
{
    public partial class App : Application
    {
        

        public App()
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.DataContext = new LoginViewModel();

            Current.MainWindow = loginWindow;

            if (loginWindow.ShowDialog() == true)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new MainViewModel();
                
                Current.MainWindow = mainWindow;
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                mainWindow.Show();
            }
            else
            {
                Current.Shutdown();
            }
        }
    }
}
