using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace DatabaseWriter
{
    public class WordsDataParser
    {

        public DataTable Parse(string wordsFilePath, IProgress<int> progress)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Words";
            string firstColumnName = "WordID";
            string secondColumnName = "word";
            dt.Columns.Add(firstColumnName);
            dt.Columns.Add(secondColumnName);

            string[] wordsData = File.ReadAllLines(wordsFilePath);
            
            foreach (var wordString in wordsData)
            {
                if (string.IsNullOrEmpty(wordString)) continue;
                var word = wordString.Split(':').First();
                DataRow row = dt.NewRow();
                row[secondColumnName] = word;
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
