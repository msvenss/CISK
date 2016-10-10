using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleCannotIncludeLetterCombinationPq: INiceRule
    {

        public bool SubStringIsAllowed(string stringToCheck)
        {
            return !stringToCheck.Contains("pq");
        }
    }
}
