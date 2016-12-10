using DatabaseWriter.ProcessStateModels;
using Microsoft.Win32;
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
    /// Interaction logic for InputFilesView2.xaml
    /// </summary>
    public partial class InputFilesView2 : UserControl
    {
        public string _inputFilePath1;
        public string _inputFilePath2;

        public InputFilesView2()
        {
            InitializeComponent();
            _inputFilePath1 = string.Empty;
            _inputFilePath2 = string.Empty;
        }

        private void ChooseFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                _inputFilePath1 = openFileDialog.FileName;
                Router.CurrentOperationModel.MapInputData(this);
            }
        }
        
        private void ChooseFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WordNet files(*.pl)|*.pl";

            if (openFileDialog.ShowDialog() == true)
            {
                _inputFilePath2 = openFileDialog.FileName;
                Router.CurrentOperationModel.MapInputData(this);
            }
        }
    }
}
