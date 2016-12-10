using DatabaseWriter.DAL;
using DatabaseWriter.Infrastructure;
using DatabaseWriter.ProcessStateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseWriter.Views
{
    /// <summary>
    /// Interaction logic for ProgressBarView.xaml
    /// </summary>
    public partial class ProgressBarView : UserControl
    {
        public ProgressBarView()
        {
            InitializeComponent();
        }

        private async void ProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<int>(percent => ProgressBar.Value = percent);
            await Task.Run(() => Router.CurrentOperationModel.ExecuteStep1(progress));
            ProgressBar.Value = 0;
            var progress2 = new Progress<int>(percent => ProgressBar.Value = percent);
            await Task.Run(() => Router.CurrentOperationModel.ExecuteStep2(progress2));
        }
    }
}
