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
        private string _definitionsFilePath;
        public string DefinitionsFilePath
        {
            private get { return _definitionsFilePath; }
            set
            {
                SetFilePath(ref _definitionsFilePath, value, 0);
            }
        }

        public DefinitionsOperationModel(InputPickerView view)
        {
            _inputView = view;
            var secondGridRow = GetGridRowChildElement(1);
            secondGridRow.Visibility = Visibility.Collapsed;
        }

        public override void Execute(IProgress<int> progress)
        {
            var parser = new DefinitionsDataParser();
            var definitionsData = parser.Parse(DefinitionsFilePath, progress);
            var repo = new Repository(progress);
            progress.Report(0);
            repo.AddUsingSqlBulkCopy(definitionsData);
        }

        public override bool MapInputData()
        {
            DefinitionsFilePath = _inputView.InputFilePath1;
            return !string.IsNullOrEmpty(DefinitionsFilePath);
        }
    }
}
