using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter
{
    public class SynsetsRelationshipParser
    {
        public DataTable Parse(string wordsFilePath, string relationshipFilePath,
            IProgress<int> progress, string tableName, string firstColumnName, string secondColumnName, char[] symbolsToTrim)
        {
            DataTable dt = new DataTable();
            dt.TableName = tableName;
            dt.Columns.Add(firstColumnName);
            dt.Columns.Add(secondColumnName);

            string[] words = File.ReadAllLines(wordsFilePath);
            string[] relatedSynsetsIDs = File.ReadAllLines(relationshipFilePath);
            Dictionary<string, List<int>> dic = MatchSynsetAndWordIDs(words);

            int onePercent = relatedSynsetsIDs.Length / 100;
            int cnt = 0;
            int currentProgress = 0;
            HashSet<string> checkOnDuplicates = new HashSet<string>();

            foreach (var pair in relatedSynsetsIDs)
            {
                if (string.IsNullOrEmpty(pair)) continue;
                var cleanString = pair.Trim(symbolsToTrim);
                var synsetIDsSeparated = cleanString.Split(',');
                if (synsetIDsSeparated[1] != "0" && synsetIDsSeparated[3] != "0") continue;
                var firstSynsetID = synsetIDsSeparated[0].Trim();
                var secondSynsetID = synsetIDsSeparated[2].Trim();
                if (!dic.Keys.Contains(firstSynsetID)) continue;
                if (!dic.Keys.Contains(secondSynsetID)) continue;
                foreach (var firstColumnWordID in dic[firstSynsetID])
                {
                    foreach (var secondColumnWordID in dic[secondSynsetID])
                    {
                        DataRow row = dt.NewRow();
                        row[firstColumnName] = firstColumnWordID;
                        row[secondColumnName] = secondColumnWordID;
                        var key = firstColumnWordID.ToString() + secondColumnWordID.ToString();
                        if (!checkOnDuplicates.Contains(key))
                        {
                            dt.Rows.Add(row);
                            checkOnDuplicates.Add(key);
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

            return d;
        }
    }
}
