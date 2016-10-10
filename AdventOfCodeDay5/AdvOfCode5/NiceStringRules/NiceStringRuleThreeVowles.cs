using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvOfCode5.NiceStringRules
{
   public class NiceStringRuleThreeVowles :INiceRule
   {
 
       public bool SubStringIsAllowed(string stringToCheck)
       {
            var isMatch = false;
          return isMatch = stringToCheck.IndexOfAny("aeiou".ToCharArray())<=3;
        }
    }
}
