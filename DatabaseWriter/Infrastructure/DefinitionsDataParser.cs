using DatabaseWriter.DAL;
using DatabaseWriter.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter
{
    public class DefinitionsDataParser : Parser 
    {
        public override Type EntityType
        {
            get
            {
                return typeof(Definition);
            }
        }

        public override IEnumerable Parse(List<string[]> data, IProgress<int> progress)
        {
            List<Definition> definitions = new List<Definition>();
            foreach (var item in data[0])
            {
                if (item == string.Empty) continue;
                var cleanLine = item.Trim('g', '(', ')', '.');

                var partOfSpeech = DefinePartOfSpeech(cleanLine);

                char[] d = new char[cleanLine.Length];
                char[] ex = new char[cleanLine.Length];

                ProcessDefinitionLine(d, ex, cleanLine);

                string definition = new string(d);

                string example = new string(ex);
                example = example.Trim(' ', '\0');

                if (example == string.Empty) example = null;

                var def = new Definition() { partOfSpeech = partOfSpeech, definition = definition.Trim(' ','\0'), example = example };
                definitions.Add(def);
            }
            return definitions.AsEnumerable();
        }

        private void ProcessDefinitionLine(char[] d, char[] ex, string s)
        {
            var defPart = s.Substring(10).Trim('\'');
            bool hasExamples = false;
            int defCount = 0;
            int exCount = 0;

            for (int i = 0; i < defPart.Length; i++)
            {
                if (defPart[i] == '\'' && defPart[i + 1] == '\'') continue;
                if (defPart[i] == '"') { hasExamples = true; continue; }
                if (hasExamples == false) { d[defCount] = defPart[i]; defCount++; }
                else { ex[exCount] = defPart[i]; exCount++; }
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
