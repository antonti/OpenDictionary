using DatabaseWriter.DAL;
using DatabaseWriter.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    class WordDefinitionOperationModel : OperationModelBase
    {
        private MultipleInputFilePicker _inputView;

        public string WordsFilePath { get; set; }

        public string DefinitionsFilePath { get; set; }

        public WordDefinitionOperationModel(MultipleInputFilePicker view)
        {
            _inputView = view;
            var irrelevantElements = view.Grid.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == 2);
            foreach (var uiElement in irrelevantElements)
            {
                uiElement.Visibility = Visibility.Visible;
            }
        }

        public override void Execute(IProgress<int> progress)
        {
            var parser = new WordDefinitionParser();
            var dataTable = parser.Parse(WordsFilePath, DefinitionsFilePath, progress);
            var repo = new Repository();
            progress.Report(0);
            repo.AddUsingSqlBulkCopy(dataTable, progress);
        }

        public override void MapInputData()
        {
                WordsFilePath = _inputView.InputFilePath1;
                DefinitionsFilePath = _inputView.InputFilePath2;
        }
   
    }
}
