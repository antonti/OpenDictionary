using DatabaseWriter.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Views
{
    /// <summary>
    /// Interaction logic for ProgressBarView.xaml
    /// </summary>
    public partial class ProgressBarView : UserControl
    {
        private OperationModelCreator _operationModelCreator;

        public ProgressBarView(OperationModelCreator opModelCreator)
        {
            InitializeComponent();
            _operationModelCreator = opModelCreator;
        }

        private async void ProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<int>(percent => ProgressBar.Value = percent);
            _operationModelCreator.CurrentOperation.MapInputData();
            await Task.Run(() => _operationModelCreator.CurrentOperation.Execute(progress));
        }
    }
}
