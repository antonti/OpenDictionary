using DatabaseWriter.DAL;
using DatabaseWriter.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    public class WordsOperationModel : OperationModelBase
    {
        private MultipleInputFilePicker _inputView;

        public string WordsFilePath { get; set; }

        public WordsOperationModel(MultipleInputFilePicker view)
        {
            _inputView = view;
            var irrelevantElements = view.Grid.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == 2);
            foreach (var uiElement in irrelevantElements)
            {
                uiElement.Visibility = Visibility.Collapsed;
            }
        }

        public override void Execute(IProgress<int> progress)
        {
            var parser = new WordsDataParser();
            var wordsData = parser.Parse(WordsFilePath, progress);
            var repo = new Repository();
            progress.Report(0);
            repo.Add(wordsData, progress);
        }

        public override void MapInputData()
        {
                WordsFilePath = _inputView.InputFilePath1;
        }
    }
}
