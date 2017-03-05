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
        private string _wordsFilePath;
        public string WordsFilePath
        {
            private get { return _wordsFilePath; }
            set
            {
                SetFilePath(ref _wordsFilePath, value, 0);
            }
        }

        public WordsOperationModel(InputPickerView view)
        {
            _inputView = view;
            var secondGridRow = GetGridRowChildElement(1);
            secondGridRow.Visibility = Visibility.Collapsed;
        }

        public override void Execute(IProgress<int> progress)
        {
            var parser = new SynonymsRelationshipParser();
            var wordsData = parser.Parse(WordsFilePath, progress);
            var repo = new Repository(progress);
            progress.Report(0);
            repo.AddUsingSqlBulkCopy(wordsData);
        }

        public override bool MapInputData()
        {
            WordsFilePath = _inputView.InputFilePath1;
            return !string.IsNullOrEmpty(WordsFilePath);
        }
    }
}
