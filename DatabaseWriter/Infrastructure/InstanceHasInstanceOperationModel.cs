using DatabaseWriter.DAL;
using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseWriter.Infrastructure
{
    public class InstanceHasInstanceOperationModel : OperationModelBase
    {
        private bool IsInputValid =>
            (string.IsNullOrEmpty(SynsetsFilePath) || string.IsNullOrEmpty(InsFilePath)) ? false : true;

        private string _synsetsFilePath;

        public string SynsetsFilePath
        {
            get { return _synsetsFilePath; }
            set
            {
                SetFilePath(ref _synsetsFilePath, value, 0);
            }
        }

        private string _insFilePath;

        public string InsFilePath
        {
            get { return _insFilePath; }
            set
            {
                SetFilePath(ref _insFilePath, value, 1);
            }
        }

        public InstanceHasInstanceOperationModel(InputPickerView view)
        {
            _inputView = view;
            var secondGridRow = GetGridRowChildElement(1);
            secondGridRow.Visibility = Visibility.Visible;
        }

        public override void Execute(IProgress<int> progress)
        {
            var parser = new SynsetsRelationshipParser();
            var dataTable = parser.Parse(SynsetsFilePath, InsFilePath, progress, "Synonyms",
                "Synonyms_Word1_WordID", "Synonyms_WordID", new char[] { 'v', 'g', 'p', '(', ')', '.' });
            var repo = new Repository(progress);
            progress.Report(0);
            repo.AddUsingSqlBulkCopy(dataTable);
        }

        public override bool MapInputData()
        {
            SynsetsFilePath = _inputView.InputFilePath1;
            InsFilePath = _inputView.InputFilePath2;
            return IsInputValid;
        }
    }
}
