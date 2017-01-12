using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    public class Router
    {
        public Dictionary<string, Func<OperationModelBase>> OperationModels { get; }

        public List<UserControl> CurrentRoute { get; }

        public OperationModelBase CurrentOperation { get; private set; }

        private string _operationType;

        public string OperationType
        {
            get { return _operationType; }
            set {
                _operationType = value;
                CurrentOperation = OperationModels[_operationType]();
            }
        }

        public Router()
        {
            OperationModels = new Dictionary<string, Func<OperationModelBase>>();
            OperationModels.Add("words", () => new WordsOperationModel((MultipleInputFilePicker)CurrentRoute[1]));
            OperationModels.Add("definitions", () => new DefinitionsOperationModel((MultipleInputFilePicker)CurrentRoute[1]));
            OperationModels.Add("word-definition relationship", () => new WordDefinitionOperationModel((MultipleInputFilePicker)CurrentRoute[1]));
            CurrentRoute = new List<UserControl>() {
                new StartupView(this),
                new MultipleInputFilePicker(this),
                new ProgressBarView(this) };
        }

    }
}
