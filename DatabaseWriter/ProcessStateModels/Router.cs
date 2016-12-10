using DatabaseWriter.Infrastructure;
using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DatabaseWriter.ProcessStateModels
{
    static class Router
    {
        private static Dictionary<string, List<Func<UserControl>>> _routes;

        private static Dictionary<string, Func<IOperationModel>> _operationModels;

        private static string _operationType;

        public static string OperationType
        {
            get { return _operationType; }
            set {
                _operationType = value;
                ChangeRoute();
            }
        }

        public static List<UserControl> CurrentRoute { get; private set; }

        public static IOperationModel CurrentOperationModel { get; private set; }

        static Router()
        {
            _routes = new Dictionary<string, List<Func<UserControl>>>();
            CurrentRoute = new List<UserControl>();
            _routes.Add("word", new List<Func<UserControl>>() {
                () => new StartupView(),
                () => new InputFilesView1(),
                () => new ProgressBarView() });
            _routes.Add("definition", new List<Func<UserControl>>() {
                () => new StartupView(),
                () => new InputFilesView1(),
                () => new ProgressBarView() });
            _routes.Add("word-definition relationship", new List<Func<UserControl>>() {
                () => new StartupView(),
                () => new InputFilesView2(),
                () => new ProgressBarView() });
            _operationModels = new Dictionary<string, Func<IOperationModel>>();
            _operationModels.Add("word", () => new WordsOperationModel());
            _operationModels.Add("definition", () => new DefinitionsOperationModel());
            _operationModels.Add("word-definition relationship", () => new WordDefinitionOperationModel());
        }

        private static void ChangeRoute()
        {
            CurrentRoute.Clear();
            foreach (var item in _routes[OperationType])
            {
                var view = item();
                CurrentRoute.Add(view);
            }
            CurrentOperationModel = _operationModels[OperationType]();
        }


    }
}
