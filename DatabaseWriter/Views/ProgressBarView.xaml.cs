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
        private Router _router;

        public ProgressBarView(Router router)
        {
            InitializeComponent();
            _router = router;
        }

        private async void ProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<int>(percent => ProgressBar.Value = percent);
            await Task.Run(() => _router.CurrentOperation.Execute(progress));
        }
    }
}
