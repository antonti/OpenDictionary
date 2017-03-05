using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter
{
    public class WordsRelationshipParser
    {
        public DataTable Parse(string wordsFilePath, string relationshipFilePath,
            IProgress<int> progress, string tableName, string firstColumnName, string secondColumnName, char[] symbolsToTrim)
        {
            DataTable dt = new DataTable();
            dt.TableName = tableName;
            dt.Columns.Add(firstColumnName);
            dt.Columns.Add(secondColumnName);
            Dictionary<string, int> wordsIDs = GetWordsIDs();
            string[] wordsData = File.ReadAllLines(wordsFilePath);
            Dictionary<string, string> words = GetWords(wordsData);
            string[] relatedWords = File.ReadAllLines(relationshipFilePath);
            float onePercent = relatedWords.Length / 100f;
            float cnt = 0;
            int currentProgress = 0;
            HashSet<string> checkOnDuplicates = new HashSet<string>();
            foreach (var item in relatedWords)
            {
                var cleanString = item.Trim(symbolsToTrim);
                var separated = cleanString.Split(',');
                int firstWordID = GetWordID(separated[0], separated[1], words, wordsIDs);
                int secondWordID = GetWordID(separated[2], separated[3], words, wordsIDs);
                if (firstWordID == 0 || secondWordID == 0) continue;
                DataRow row = dt.NewRow();
                row[firstColumnName] = firstWordID;
                row[secondColumnName] = secondWordID;
                var key = firstWordID.ToString() + secondWordID.ToString();
                if (!checkOnDuplicates.Contains(key))
                {
                    dt.Rows.Add(row);
                    checkOnDuplicates.Add(key);
                }
                
                cnt++;
                if (cnt % onePercent == 0) { currentProgress++; progress.Report(currentProgress); }
            }
            progress.Report(100);
            return dt;
        }

        private Dictionary<string, string> GetWords(string[] words)
        {
            var dic = new Dictionary<string, string>();
            foreach (var line in words)
            {
                var cleanLine = line.Trim('s', '(', ')', '.');
                var separated = cleanLine.Split(',');
                string key = separated[0] + separated[1];
                var word = separated[2].Trim('\'');
                var index = word.IndexOf('\'');
                if (index > 0) word = word.Remove(index, 1);
                if(!dic.ContainsKey(key)) dic.Add(key, word);
            }
            return dic;
        }

        private int GetWordID(string synsetID, string wnum, Dictionary<string, string> words, Dictionary<string, int> IDs)
        {
            var key = synsetID + wnum;
            var word = words.ContainsKey(key)? words[key] : string.Empty;
            int ID = IDs.ContainsKey(word)? IDs[word] : 0;
            return ID;
        }

        private Dictionary<string, int> GetWordsIDs()
        {
            var dic = new Dictionary<string, int>();
            var path = "C:\\words.txt";
            var words = File.ReadAllLines(path);
            int wordID = 0;
            foreach (var item in words)
            {
                if (string.IsNullOrEmpty(item)) continue;
                wordID++;
                var word = item.Split(':').First();
                dic.Add(word, wordID);
            }
            return dic;
        }
    }
}
