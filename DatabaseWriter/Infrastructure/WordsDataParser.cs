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
    public class WordsDataParser
    {

        public IEnumerable<Word> Parse(string[] data, IProgress<int> progress)
        {
            List<Word> words = new List<Word>();
            foreach (var item in data)
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
