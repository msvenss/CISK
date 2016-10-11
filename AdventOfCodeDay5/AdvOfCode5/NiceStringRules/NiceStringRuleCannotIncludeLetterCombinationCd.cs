namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleCannotIncludeLetterCombinationCd : INiceRule
    {
        public bool SubStringIsAllowed(string stringToCheck)
        {
            return !stringToCheck.Contains("cd");
        }
    }
}