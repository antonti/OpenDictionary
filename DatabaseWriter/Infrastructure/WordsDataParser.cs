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
    public class WordsDataParser : Parser
    {
        public override Type EntityType
        {
            get
            {
                return typeof(Word);
            }
        }

        public override IEnumerable Parse(List<string[]> data, IProgress<int> progress)
        {
            List<Word> words = new List<Word>();
            foreach (var item in data[0])
            {
                if (item == string.Empty) continue;
                var word = item.Split(':').First();
                var w = new Word() { word = word };
                words.Add(w);
            }
            return words.AsEnumerable();
        }

    }
}
