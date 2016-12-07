using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.Infrastructure
{
    public abstract class Parser
    {
        public abstract Type EntityType { get; }
        
        public abstract IEnumerable Parse(List<string[]> a, IProgress<int> progress);

    }
}
