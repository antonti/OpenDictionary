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
            /* Each string in "wordsData" contains a word with all the synsets' information.
               Synset - set of synonyms in the WordNet which I used as a source.
               "wordsFile" was separately written in format:
               word:synsetID,part of speech,number for sorting word's definitions;...,...,...;+ */
            string[] wordsData = File.ReadAllLines(wordsFilePath);
            
            // "definitionsData" contains definitions with examples for words in original format of the WordNet's prolog version
            string[] definitionsData = File.ReadAllLines(definitionsFilePath);

            /* Parsing "definitions" to get original IDs to match words and definitions that were 
            separately loaded into database using this app.
            Using class Dictionary to avoid parsing the file multiple times. */   
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

            /* "definitionDatabaseID" reflects "definitionID" in the database 
            by ordering in the input file which is precise */
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
