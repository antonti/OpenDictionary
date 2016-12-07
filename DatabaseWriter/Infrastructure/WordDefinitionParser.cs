using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.Infrastructure
{
    class WordDefinitionParser : Parser
    {
        public override Type EntityType
        {
            get
            {
                return typeof(Word);
            }
        }

        public override IEnumerable Parse(List<string[]> a, IProgress<int> progress)
        {
            List<Word> words = new List<Word>();
            Dictionary<string, int> defIds = new Dictionary<string, int>();
            int id2 = 0;
            foreach (var item in a[1])
            {
                var id = item.TrimStart('g', '(').Substring(0, 9);
                id2++;
                defIds.Add(id, id2);
            }

            int onePercent = a[0].Length/100;
            int wordID = 0;
            int curPercent = 0;

            foreach (var item in a[0])
            {
                var w = new Word();
                if (item == string.Empty) continue;
                wordID++;
                var splitLine = item.Split(':'); 
                var word = splitLine.First();
                w.WordID = wordID;
                w.word = word;
                var synsetsInfo = splitLine.Last().Split(';');
                foreach (var syn in synsetsInfo)
                {
                    if (syn == string.Empty) continue;
                    var synsetID = syn.Split(',').First();
                    int definitionID = defIds[synsetID];
                    w.Definitions.Add(new Definition() { DefinitionID = definitionID });
                }

                words.Add(w);

                if (wordID % onePercent == 0) { curPercent++; progress.Report(curPercent); }
            }

            progress.Report(100);
            return words;
        }
    }
}
