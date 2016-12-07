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

        private static Dictionary<string, Func<Parser>> _parsers;

        private static string _operationType;

        public static string OperationType
        {
            get { return _operationType; }
            set {
                _operationType = value;
                ChangeRoute();
            }
        }

        public static string[] Input { get; set; }

        public static List<UserControl> CurrentRoute { get; private set; }

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
            _parsers = new Dictionary<string, Func<Parser>>();
            _parsers.Add("word", () => new WordsDataParser());
            _parsers.Add("definition", () => new DefinitionsDataParser());
            _parsers.Add("word-definition relationship", () => new WordDefinitionParser());
        }

        private static void ChangeRoute()
        {
            CurrentRoute.Clear();
            foreach (var item in _routes[OperationType])
            {
                var view = item();
                CurrentRoute.Add(view);
            }
        }

        public static Parser GetSuitableParser()
        {
            return _parsers[OperationType]();
        }


    }
}
