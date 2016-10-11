namespace AdvOfCode5.NiceStringRules
{
    public class NiceStringRuleCannotIncludeLetterCombinationPq : INiceRule
    {
        public bool SubStringIsAllowed(string stringToCheck)
        {
            return !stringToCheck.Contains("pq");
        }
    }
}