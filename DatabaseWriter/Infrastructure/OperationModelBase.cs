using System;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    public abstract class OperationModelBase
    {
        public abstract void Execute(IProgress<int> progress);

        public abstract void MapInputData();

    }
}
