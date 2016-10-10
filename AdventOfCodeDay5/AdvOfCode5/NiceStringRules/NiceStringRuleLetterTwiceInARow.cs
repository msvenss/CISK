using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvOfCode5.NiceStringRules
{
  public class NiceStringRuleLetterTwiceInARow :INiceRule
  {

      public bool SubStringIsAllowed(string stringToCheck)
      {
          var isMatch = false;
          for (var i = 0; i < stringToCheck.Length -1; i++)
          {
              var substring = stringToCheck.Substring(i, 2);
              if (substring.ElementAt(0) != substring.ElementAt(1)) continue;
              isMatch = true;
              break;;
          }
          return isMatch;
      }
    }
}
