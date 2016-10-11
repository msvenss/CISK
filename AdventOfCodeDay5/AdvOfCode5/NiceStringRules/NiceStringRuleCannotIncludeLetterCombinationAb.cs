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