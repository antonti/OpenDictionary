using DatabaseWriter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DatabaseWriter
{
    public class WordsOperationModel : IOperationModel
    {
        public string InputFilePath { get; set; }

        public void ExecuteStep1(IProgress<int> p)
        {
            throw new NotImplementedException();
        }

        public void ExecuteStep2(IProgress<int> p)
        {
            throw new NotImplementedException();
        }

        public void MapInputData(UserControl view)
        {
            throw new NotImplementedException();
        }
    }
}
