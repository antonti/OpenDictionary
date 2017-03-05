using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter
{
    public class SynonymsRelationshipParser
    {
        public DataTable Parse(string synsetsFilePath, IProgress<int> progress)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Synonyms";
            string firstColumnName = "Synonyms_Word1_WordID";
            string secondColumnName = "Synonyms_WordID";
            dt.Columns.Add(firstColumnName);
            dt.Columns.Add(secondColumnName);
            string[] synsets = File.ReadAllLines(synsetsFilePath);
            HashSet<string> checkOnDuplicates = new HashSet<string>();
            float onePercent = synsets.Length / 100f;
            float cnt = 0;
            int currentProgress = 0;
            foreach (var item in synsets)
            {
                var synonymsList = item.Split(':').Last().Split(',').ToList();
                foreach (var word in synonymsList)
                {
                    var ID = int.Parse(word);
                    foreach (var word2 in synonymsList)
                    {
                        var ID2 = int.Parse(word2);
                        if (ID == ID2) continue;
                        DataRow row = dt.NewRow();
                        row[firstColumnName] = ID;
                        row[secondColumnName] = ID2;
                        var key = word + word2;
                        if(!checkOnDuplicates.Contains(key)) dt.Rows.Add(row);
                        checkOnDuplicates.Add(key);
                    }
                }
                cnt++;
                if (cnt % onePercent == 0) { currentProgress++; progress.Report(currentProgress); }
            }

            progress.Report(100);
            return dt;
        }
    }
}
