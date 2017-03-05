using DatabaseWriter.DAL;
using DatabaseWriter.Views;
using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    class WordDefinitionOperationModel : OperationModelBase
    {
        private bool IsInputValid =>
            (string.IsNullOrEmpty(WordsFilePath) || string.IsNullOrEmpty(DefinitionsFilePath)) ? false : true;

        private string _wordsFilePath;
        public string WordsFilePath
        {
            private get { return _wordsFilePath; }
            set
            {
                SetFilePath(ref _wordsFilePath, value, 0);
            }
        }

        private string _definitionsFilePath;
        public string DefinitionsFilePath
        {
            private get { return _definitionsFilePath; }
            set
            {
                SetFilePath(ref _definitionsFilePath, value, 1);
            }
        }

        public WordDefinitionOperationModel(InputPickerView view)
        {
            _inputView = view;
            var secondGridRow = GetGridRowChildElement(1);
            secondGridRow.Visibility = Visibility.Visible;
        }

        public override void Execute(IProgress<int> progress)
        {
            var parser = new WordDefinitionParser();
            var dataTable = parser.Parse(WordsFilePath, DefinitionsFilePath, progress);
            var repo = new Repository(progress);
            progress.Report(0);
            repo.AddUsingSqlBulkCopy(dataTable);
        }

        public override bool MapInputData()
        {
            WordsFilePath = _inputView.InputFilePath1;
            DefinitionsFilePath = _inputView.InputFilePath2;
            return IsInputValid;
        }

    }
}
