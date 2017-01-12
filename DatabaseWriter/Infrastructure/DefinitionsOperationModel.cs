using DatabaseWriter.DAL;
using DatabaseWriter.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    class DefinitionsOperationModel : OperationModelBase
    {
        private MultipleInputFilePicker _inputView;

        public string DefinitionsFilePath { get; set; }

        public DefinitionsOperationModel(MultipleInputFilePicker view)
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
            var parser = new DefinitionsDataParser();
            var definitionsData = parser.Parse(DefinitionsFilePath, progress);
            var repo = new Repository();
            progress.Report(0);
            repo.Add(definitionsData, progress);
        }

        public override void MapInputData()
        {
                DefinitionsFilePath = _inputView.InputFilePath1;
        }
    }
}
