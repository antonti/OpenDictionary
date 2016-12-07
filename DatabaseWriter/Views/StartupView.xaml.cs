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
    /// Interaction logic for StartupView.xaml
    /// </summary>
    public partial class StartupView : UserControl
    {
        private string _operationType;

        public StartupView()
        {
            InitializeComponent();
            _operationType = string.Empty;
           
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _operationType = comboBox.SelectedValue.ToString();
            Router.OperationType = _operationType;
        }
    }
}
