using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.Infrastructure
{
    public interface IValidatable
    {
        bool IsValid();
    }
}
