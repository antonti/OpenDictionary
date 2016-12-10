using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    interface IOperationModel
    {
        void ExecuteStep1(IProgress<int> p);

        void ExecuteStep2(IProgress<int> p);

        void MapInputData(UserControl view);
    }
}
