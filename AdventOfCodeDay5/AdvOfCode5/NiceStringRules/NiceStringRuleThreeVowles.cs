namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleThreeVowles : INiceRule
    {
        public bool SubStringIsAllowed(string stringToCheck)
        {
            if (stringToCheck.Length > 2) { 
            return stringToCheck.IndexOfAny("aeiou".ToCharArray()) <= 3;
            }
            return false;
        }
    }
}