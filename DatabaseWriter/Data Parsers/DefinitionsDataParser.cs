using System;
using System.Collections.Generic;
using System.IO;

namespace DatabaseWriter
{
    public class DefinitionsDataParser
    {

        public IEnumerable<Definition> Parse(string definitionsFilePath, IProgress<int> progress)
        {
            string[] definitionsData = File.ReadAllLines(definitionsFilePath);
            List<Definition> definitions = new List<Definition>();
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

                var fullDefinition = new Definition() { partOfSpeech = partOfSpeech, definition = definition.Trim(' ','\0'), example = example };
                definitions.Add(fullDefinition);
            }
            return definitions;
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
