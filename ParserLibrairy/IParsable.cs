using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPackage.Parser
{
    public interface IParsable <T> where T : class
    {
        string Encode();
    }
}
