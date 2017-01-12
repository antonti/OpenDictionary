using DatabaseWriter.Infrastructure;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Views
{
    /// <summary>
    /// Interaction logic for InputFilesView2.xaml
    /// </summary>
    public partial class MultipleInputFilePicker : UserControl
    {
        private Router _router;

        public string InputFilePath1 { get; private set; }
        public string InputFilePath2 { get; private set; }

        public MultipleInputFilePicker(Router router)
        {
            InitializeComponent();
            _router = router;
            InputFilePath1 = string.Empty;
            InputFilePath2 = string.Empty;
        }

        private void ChooseFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                InputFilePath1 = openFileDialog.FileName;
                _router.CurrentOperation.MapInputData();
            }
        }
        
        private void ChooseFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WordNet files(*.pl)|*.pl";

            if (openFileDialog.ShowDialog() == true)
            {
                InputFilePath2 = openFileDialog.FileName;
                _router.CurrentOperation.MapInputData();
            }
        }
    }
}
