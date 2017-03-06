using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace DatabaseWriter
{
    public class DefinitionsDataParser
    {

        public DataTable Parse(string definitionsFilePath, IProgress<int> progress)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Definitions";
            string firstColumnName = "DefinitionID";
            string secondColumnName = "partOfSpeech";
            string thirdColumnName = "definition";
            string fourthColumnName = "example";

            dt.Columns.Add(firstColumnName);
            dt.Columns.Add(secondColumnName);
            dt.Columns.Add(thirdColumnName);
            dt.Columns.Add(fourthColumnName);

            string[] definitionsData = File.ReadAllLines(definitionsFilePath);
            
            foreach (var definitionString in definitionsData)
            {
                if (string.IsNullOrEmpty(definitionString)) continue;
                var cleanLine = definitionString.Trim('g', '(', ')', '.');

                var partOfSpeech = DefinePartOfSpeech(cleanLine);

                char[] d = new char[cleanLine.Length];
                char[] ex = new char[cleanLine.Length];

                ProcessDefinitionLine(d, ex, cleanLine);

                string definition = new string(d);

                string example = new string(ex);
                example = example.Trim(' ', '\0');

                if (string.IsNullOrEmpty(example)) example = null;

                DataRow row = dt.NewRow();
                row[secondColumnName] = partOfSpeech;
                row[thirdColumnName] = definition.Trim(' ', '\0');
                row[fourthColumnName] = example;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void ProcessDefinitionLine(char[] d, char[] ex, string s)
        {
            var definitionPart = s.Substring(10).Trim('\'');
            bool hasExamples = false;
            int defCount = 0;
            int exCount = 0;

            for (int i = 0; i < definitionPart.Length; i++)
            {
                if (definitionPart[i] == '\'' && definitionPart[i + 1] == '\'') continue;
                if (definitionPart[i] == '"') { hasExamples = true; continue; }
                if (hasExamples == false) { d[defCount] = definitionPart[i]; defCount++; }
                else { ex[exCount] = definitionPart[i]; exCount++; }
            }
        }

        private string DefinePartOfSpeech(string src)
        {
            var posNumber = src[0];
            switch (posNumber)
            {
                case '1': return "noun";
                case '2': return "verb";
                case '3': return "adj.";
                case '4': return "adv.";
                default: return null;
            }
        }

    }
}
