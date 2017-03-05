using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    public class OperationModelCreator
    {
        public Dictionary<string, Func<OperationModelBase>> OperationModels { get; }

        public OperationModelBase CurrentOperation { get; private set; }

        public OperationModelCreator(InputPickerView inputView)
        {
            OperationModels = new Dictionary<string, Func<OperationModelBase>>();
            OperationModels.Add("words", () => new WordsOperationModel(inputView));
            OperationModels.Add("definitions", () => new DefinitionsOperationModel(inputView));
            OperationModels.Add("word-definition relationship", () => new WordDefinitionOperationModel(inputView));
            OperationModels.Add("hyponym-hypernym relationship", () => new HyponymHypernymOperationModel(inputView));
            OperationModels.Add("instance-hasInstance relationship", () => new InstanceHasInstanceOperationModel(inputView));
        }

        public void InitializeCurrentOperation(string operationType)
        {
            CurrentOperation = OperationModels[operationType]();
        }

    }
}
