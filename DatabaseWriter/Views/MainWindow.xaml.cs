using DatabaseWriter.Infrastructure;
using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<UserControl> _views;
        private int _currentPage;

        public MainWindow(StartupView startupView, InputPickerView inputView, ProgressBarView progressView)
        {
            InitializeComponent();
            _views = new List<UserControl>() { startupView, inputView, progressView };
            _currentPage = 0;
            View.Content = _views[_currentPage];
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (((IValidatable)_views[_currentPage]).IsValid())
                View.Content = _views[++_currentPage];
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            View.Content = _views[--_currentPage];
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
