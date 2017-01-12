using DatabaseWriter.Infrastructure;
using System.Windows;

namespace DatabaseWriter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Router router = new Router();
            MainWindow mainWindow = new MainWindow(router);
            mainWindow.Show();
        }
    }
}
