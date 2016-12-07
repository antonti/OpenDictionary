using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.Infrastructure
{
    class Reader
    {
        public List<string[]> Read(IEnumerable<string> paths)
        {
            List<string[]> dataSets = new List<string[]>();

            foreach (var item in paths)
            {
                var array = File.ReadAllLines(item);
                dataSets.Add(array);
            }
            return dataSets;
        }
    }
}
