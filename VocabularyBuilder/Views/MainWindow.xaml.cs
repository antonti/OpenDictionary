using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.Windows.Data;
using System;

namespace VocabularyBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string _queryWord;
         
        public MainWindow()
        {
            InitializeComponent();
            _queryWord = string.Empty;
        }


        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Query_TextChanged(object sender, TextChangedEventArgs e)
        {
            _queryWord = Query.Text.Trim();


        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            AddInfo.IsExpanded = true;
            
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            AddInfo.IsExpanded = false;
        }

        private void Result_ContentChanged(WordData sender, EventArgs e)
        {
            Group();
        }

        private void Group()
        {
            if (Result.ItemsSource != null)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Result.ItemsSource);
                PropertyGroupDescription description = new PropertyGroupDescription("SynsetType");
                view.GroupDescriptions.Add(description);
            }
        }
    }
}
