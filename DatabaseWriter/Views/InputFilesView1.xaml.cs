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
    /// Interaction logic for InputFilesView1.xaml
    /// </summary>
    public partial class InputFilesView1 : UserControl
    {
        private string _inputFilePath;

        public InputFilesView1()
        {
            InitializeComponent();
            _inputFilePath = string.Empty;
            Router.Input = new string[1];
        }

        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                _inputFilePath = openFileDialog.FileName;
                Router.Input[0] = _inputFilePath;
            }
        }
    }
}
