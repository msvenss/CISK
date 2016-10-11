namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleCannotIncludeLetterCombinationXy : INiceRule
    {
        public bool SubStringIsAllowed(string stringToCheck)
        {
            return !stringToCheck.Contains("xy");
        }
    }
}