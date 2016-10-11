using System.Linq;

namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleLetterTwiceInARow : INiceRule
    {
        public bool SubStringIsAllowed(string stringToCheck)
        {
            var isMatch = false;
            if (stringToCheck.Length <= 1) return false;
            for (var i = 0; i < stringToCheck.Length - 1; i++)
            {
                var substring = stringToCheck.Substring(i, 2);
                if (substring.ElementAt(0) == substring.ElementAt(1))
                {
                    isMatch = true;
                }
            }
            return isMatch;
        }
    }
}