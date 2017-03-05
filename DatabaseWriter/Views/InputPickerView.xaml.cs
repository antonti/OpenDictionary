using DatabaseWriter.Infrastructure;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System;

namespace DatabaseWriter.Views
{
    /// <summary>
    /// Interaction logic for InputFilesView2.xaml
    /// </summary>
    public partial class InputPickerView : UserControl, IValidatable
    {
        public string InputFilePath1 { get; private set; }
        public string InputFilePath2 { get; private set; }
        public OperationModelCreator OperationModelCreator { private get; set; } 

        public InputPickerView()
        {
            InitializeComponent();
            InputFilePath1 = string.Empty;
            InputFilePath2 = string.Empty;
        }

        private void ChooseFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Text files(*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                InputFilePath1 = openFileDialog.FileName;
                Input1.Text = InputFilePath1;
                InputInstruction1.Text = string.Empty;
            }
        }
        
        private void ChooseFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WordNet files(*.pl)|*.pl";

            if (openFileDialog.ShowDialog() == true)
            {
                InputFilePath2 = openFileDialog.FileName;
                Input2.Text = InputFilePath2;
                InputInstruction2.Text = string.Empty;
            }
        }

        private void Input1_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFilePath1 = Input1.Text;
            InputInstruction1.Text = string.Empty;
        }

        private void Input2_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFilePath2 = Input2.Text;
            InputInstruction2.Text = string.Empty;
        }

        public bool IsValid()
        {
            return OperationModelCreator.CurrentOperation.MapInputData();
        }
    }
}
