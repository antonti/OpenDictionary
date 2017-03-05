using DatabaseWriter.DAL;
using DatabaseWriter.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseWriter.Infrastructure
{
    public class HyponymHypernymOperationModel : OperationModelBase
    {
        private bool IsInputValid =>
            (string.IsNullOrEmpty(WordsFilePath) || string.IsNullOrEmpty(HyponymsHypernymsFilePath)) ? false : true;

        private string _wordsFilePath;

        public string WordsFilePath
        {
            private get { return _wordsFilePath; }
            set
            {
                SetFilePath(ref _wordsFilePath, value, 0);
            }
        }

        private string _hyponymsHypernymsFilePath;

        public string HyponymsHypernymsFilePath
        {
            get { return _hyponymsHypernymsFilePath; }
            set
            {
                SetFilePath(ref _hyponymsHypernymsFilePath, value, 1);
            }
        }

        public HyponymHypernymOperationModel(InputPickerView view)
        {
            _inputView = view;
            var secondGridRow = GetGridRowChildElement(1);
            secondGridRow.Visibility = Visibility.Visible;
        }

        public override void Execute(IProgress<int> progress)
        {
            var dt = Parse(WordsFilePath, HyponymsHypernymsFilePath, progress);
            var repo = new Repository(progress);
            progress.Report(0);
            repo.AddUsingSqlBulkCopy(dt);
        }

        public override bool MapInputData()
        {
            WordsFilePath = _inputView.InputFilePath1;
            HyponymsHypernymsFilePath = _inputView.InputFilePath2;
            return IsInputValid;
        }

        DataTable Parse(string wordsFilePath, string hypoHyperFilePath, IProgress<int> progress)
        {
            DataTable dt = new DataTable();
            dt.TableName = "HyponymHypernym";
            string hyponymWordID = "Hyponyms_WordID";
            string hypernymWordID = "Hypernyms_WordID";
            dt.Columns.Add(hyponymWordID);
            dt.Columns.Add(hypernymWordID);

            string[] words = File.ReadAllLines(wordsFilePath);
            string[] hyponymsHypernyms = File.ReadAllLines(hypoHyperFilePath);
            Dictionary<string, List<int>> dic = MatchSynsetAndWordIDs(words);

            int onePercent = hyponymsHypernyms.Length / 100;
            int cnt = 0;
            int currentProgress = 0;
            HashSet<string> hyps = new HashSet<string>();

            foreach (var pair in hyponymsHypernyms)
            {
                if (string.IsNullOrEmpty(pair)) continue;
                var cleanString = pair.Trim('h', 'y', 'p', '(', ')', '.');
                var synsetIDsSeparated = cleanString.Split(',');
                var hyponymSynsetID = synsetIDsSeparated.First().Trim();
                var hypernymSynsetID = synsetIDsSeparated.Last().Trim();
                if (!dic.Keys.Contains(hyponymSynsetID)) continue;
                foreach (var hyponym in dic[hyponymSynsetID])
                {
                    if (!dic.Keys.Contains(hypernymSynsetID)) continue;
                    foreach (var hypernym in dic[hypernymSynsetID])
                    {
                        DataRow row = dt.NewRow();
                        row[hyponymWordID] = hyponym;
                        row[hypernymWordID] = hypernym;
                        var key = hyponym.ToString() + hypernym.ToString();
                        if (!hyps.Contains(key))
                        {
                            dt.Rows.Add(row);
                            hyps.Add(key);
                        }
                    }
                    
                }
                cnt++;
                if (cnt % onePercent == 0) { currentProgress++; progress.Report(currentProgress); }
            }
            progress.Report(100);
            return dt;
        }

        private Dictionary<string, List<int>> MatchSynsetAndWordIDs(string[] words)
        {
            //Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();

            Dictionary<string, List<int>> d = new Dictionary<string, List<int>>();

            foreach (var item in words)
            {
                if (string.IsNullOrEmpty(item)) continue;
                var separatedLine = item.Trim().Split(':');
                var synsetID = separatedLine.First();
                var wordsList = separatedLine.Last().Split(',');
                d.Add(synsetID, new List<int>());
                foreach (var word in wordsList)
                {
                    d[synsetID].Add(int.Parse(word));
                }
            }
            //int wordID = 0;
            //foreach (var item in words)
            //{
            //    if (string.IsNullOrEmpty(item)) continue;
            //    wordID++;
            //    var list = new List<string>();
            //    var splitString = item.Trim().Split(':');
            //    var synsets = splitString.Last().Split(';');
            //    foreach (var synset in synsets)
            //    {
            //        if (string.IsNullOrEmpty(synset)) continue;
            //        var synsetID = synset.Substring(0, 9);
            //        list.Add(synsetID);
            //    }
            //    dic.Add(wordID, list);
            //}

            //Dictionary<string, List<int>> d = new Dictionary<string, List<int>>();
            //foreach (var item in dic)
            //{
            //    foreach (var syn in item.Value)
            //    {
            //        if (!d.ContainsKey(syn))
            //        {
            //            d.Add(syn, new List<int>());
            //            d[syn].Add(item.Key);
            //        }
            //        else if(!d[syn].Contains(item.Key))d[syn].Add(item.Key);
            //    }
            //}

            //using (StreamWriter wr = new StreamWriter("C:\\synsets.txt"))
            //{
            //    foreach (var item in d)
            //    {
            //        wr.Write(item.Key);
            //        wr.Write(':');
            //        for(int i = 0; i < item.Value.Count; i++)
            //        {
            //            wr.Write(item.Value[i]);
            //            if(i < item.Value.Count-1)wr.Write(',');
            //        }
            //        wr.WriteLine();
            //    }
            //}
            return d;
        }
    }
}
