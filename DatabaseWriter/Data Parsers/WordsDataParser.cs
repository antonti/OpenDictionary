using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DatabaseWriter
{
    public class WordsDataParser
    {

        public IEnumerable<Word> Parse(string wordsFilePath, IProgress<int> progress)
        {
            string[] wordsData = File.ReadAllLines(wordsFilePath);
            List<Word> words = new List<Word>();
            foreach (var wordString in wordsData)
            {
                if (string.IsNullOrEmpty(wordString)) continue;
                var word = wordString.Split(':').First();
                var w = new Word() { word = word };
                words.Add(w);
            }
            return words;
        }

    }
}
