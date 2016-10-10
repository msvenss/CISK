using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvOfCode5.NiceStringRules
{
    public interface INiceRule
    {
        bool SubStringIsAllowed(string stringToCheck);
   
    }
}
