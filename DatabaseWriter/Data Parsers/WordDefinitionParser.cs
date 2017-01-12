using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace DatabaseWriter
{
    class WordDefinitionParser
    {
        public DataTable Parse(string wordsFilePath, string definitionsFilePath, IProgress<int> progress)
        {
            string[] wordsData = File.ReadAllLines(wordsFilePath);
            string[] definitionsData = File.ReadAllLines(definitionsFilePath);

            Dictionary<string, int> definitionIDs = GetDefinitionIDs(definitionsData);

            DataTable dt = new DataTable();
            dt.TableName = "WordDefinition";
            string wordIDColumn = "Words_WordID";
            string definitionIDColumn = "Definitions_DefinitionID";
            dt.Columns.Add(wordIDColumn);
            dt.Columns.Add(definitionIDColumn);

            int onePercent = wordsData.Length/100;
            int wordID = 0;
            int currentProgress = 0;

            foreach (var wordString in wordsData)
            {
                if (string.IsNullOrEmpty(wordString)) continue;
                wordID++; 
                string[] synsetsData = wordString.Split(':').Last().Split(';');
                foreach (var synset in synsetsData)
                {
                    if (string.IsNullOrEmpty(synset)) continue;
                    var synsetID = synset.Split(',').First();
                    int definitionID = definitionIDs[synsetID];
                    DataRow row = dt.NewRow();
                    row[wordIDColumn] = wordID;
                    row[definitionIDColumn] = definitionID;
                    dt.Rows.Add(row);
                }

                if (wordID % onePercent == 0) { currentProgress++; progress.Report(currentProgress); }
            }

            progress.Report(100);
            return dt;
        }

        private Dictionary<string, int> GetDefinitionIDs(string[] definitions)
        {
            var definitionIDs = new Dictionary<string, int>();
            int definitionDatabaseID = 0;
            foreach (var definition in definitions)
            {
                var synsetID = definition.TrimStart('g', '(').Substring(0, 9);
                definitionDatabaseID++;
                definitionIDs.Add(synsetID, definitionDatabaseID);
            }

            return definitionIDs;
        }
    }
}
