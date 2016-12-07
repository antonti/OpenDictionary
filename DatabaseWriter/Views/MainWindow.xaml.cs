using DatabaseWriter.Infrastructure;
using DatabaseWriter.ProcessStateModels;
using DatabaseWriter.Views;
using Microsoft.Win32;
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
        
        private int _currentPage;

        public MainWindow()
        {
            InitializeComponent();
            View.Content = new StartupView();
            _currentPage = 0;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            View.Content = Router.CurrentRoute[++_currentPage];
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            View.Content = Router.CurrentRoute[--_currentPage];
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
