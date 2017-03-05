using DatabaseWriter.Infrastructure;
using DatabaseWriter.Views;
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
            InputPickerView inputView = new InputPickerView();
            OperationModelCreator operationModelCreator = new OperationModelCreator(inputView);
            inputView.OperationModelCreator = operationModelCreator;
            StartupView startupView = new StartupView(operationModelCreator);
            ProgressBarView progressView = new ProgressBarView(operationModelCreator);
            MainWindow mainWindow = new MainWindow(startupView,inputView,progressView);
            mainWindow.Show();
        }
    }
}
