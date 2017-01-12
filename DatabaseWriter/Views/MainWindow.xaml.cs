using DatabaseWriter.Infrastructure;
using DatabaseWriter.Views;
using System;
using System.Windows;

namespace DatabaseWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _currentPage;

        private Router _router;

        public MainWindow(Router router)
        {
            InitializeComponent();
            _router = router;
            _currentPage = 0;
            View.Content = _router.CurrentRoute[_currentPage];
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            View.Content = _router.CurrentRoute[++_currentPage];
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            View.Content = _router.CurrentRoute[--_currentPage];
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
