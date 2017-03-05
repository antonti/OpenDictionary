using DatabaseWriter.Infrastructure;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DatabaseWriter.Views
{
    /// <summary>
    /// Interaction logic for StartupView.xaml
    /// </summary>
    public partial class StartupView : UserControl, IValidatable
    {
        private string _operationType;
        private OperationModelCreator _operationModelCreator;

        public StartupView(OperationModelCreator opModelCreator)
        {
            InitializeComponent();
            _operationModelCreator = opModelCreator;
            _operationType = string.Empty;
            comboBox.ItemsSource = _operationModelCreator.OperationModels.Keys.ToList();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _operationType = comboBox.SelectedItem?.ToString();
            _operationModelCreator.InitializeCurrentOperation(_operationType);
        }

        public bool IsValid()
        {
            return (string.IsNullOrEmpty(_operationType)) ? false : true;
        }
    }
}
