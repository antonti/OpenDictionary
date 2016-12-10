using DatabaseWriter.DAL;
using DatabaseWriter.Infrastructure;
using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DatabaseWriter
{
    class WordDefinitionOperationModel : IOperationModel
    {
        private DataTable _dt;

        public string InputFilePath1 { get; set; }

        public string InputFilePath2 { get; set; }

        public void ExecuteStep1(IProgress<int> progress)
        {
            var reader = new Reader();
            var data = reader.Read(InputFilePath1, InputFilePath2);
            var parser = new WordDefinitionParser();
            _dt = parser.Parse(data, progress);
        }

        public void ExecuteStep2(IProgress<int> progress)
        {
            var repo = new Repository();
            repo.AddUsingSqlBulkCopy(_dt, progress);

        }

        public void MapInputData(UserControl view)
        {
            if(view is InputFilesView2)
            {
                var v = (InputFilesView2)view;
                InputFilePath1 = v._inputFilePath1;
                InputFilePath2 = v._inputFilePath2;
            }
        }
    }
}
