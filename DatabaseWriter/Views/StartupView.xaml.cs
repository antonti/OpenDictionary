using DatabaseWriter.Infrastructure;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;

namespace DatabaseWriter.Views
{
    /// <summary>
    /// Interaction logic for StartupView.xaml
    /// </summary>
    public partial class StartupView : UserControl
    {
        private string _operationType;

        private Router _router;

        public StartupView(Router router)
        {
            InitializeComponent();
            _router = router;
            _operationType = string.Empty;
            comboBox.ItemsSource = _router.OperationModels.Keys.ToList();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _operationType = comboBox.SelectedItem.ToString();
            _router.OperationType = _operationType;
        }
    }
}
