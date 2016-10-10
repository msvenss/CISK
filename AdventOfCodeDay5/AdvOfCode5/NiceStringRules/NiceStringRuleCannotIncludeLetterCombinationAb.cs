using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleCannotIncludeLetterCombinationAb : INiceRule
    {
        public bool SubStringIsAllowed(string stringToCheck)
        {
            return !stringToCheck.Contains("ab");

        }
    }
}
