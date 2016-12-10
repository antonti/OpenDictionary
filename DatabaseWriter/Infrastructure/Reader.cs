using System.Collections.Generic;
using System.IO;

namespace DatabaseWriter.Infrastructure
{
    class Reader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }

        public List<string[]> Read(string path1, string path2)
        {
            List<string[]> dataSet = new List<string[]>();

            var array1 = File.ReadAllLines(path1);
            var array2 = File.ReadAllLines(path2);
            dataSet.Add(array1);
            dataSet.Add(array2);

            return dataSet;
        }
    }
}
