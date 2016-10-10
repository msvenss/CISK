using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvOfCode5.NiceStringRules;
using NUnit.Framework;
using FluentAssertions;

namespace AdvOfCode5.Tests
{
    [TestFixture]
   public class StringCheckerTests
    {
        private StringChecker _stringChecker;
        private string _strigToCheck;
        private IEnumerable<INiceRule> _rules;
        private NiceStringRuleCannotIncludeLetterCombinationAb _ruleCannotIncludeLetterCombinationAb;
        private NiceStringRuleCannotIncludeLetterCombinationCd _ruleCannotIncludeLetterCombinationCd;
        private NiceStringRuleCannotIncludeLetterCombinationPq _ruleCannotIncludeLetterCombinationPq;
        private NiceStringRuleCannotIncludeLetterCombinationXy _ruleCannotIncludeLetterCombinationXy;
        private NiceStringRuleLetterTwiceInARow _ruleTwoLetterTwiceInARow;
        private NiceStringRuleThreeVowles _ruleThreeVowles;



        [SetUp]
        public void SetUp()
        {
            _stringChecker = new StringChecker(_strigToCheck, _rules);
            _ruleCannotIncludeLetterCombinationAb = new NiceStringRuleCannotIncludeLetterCombinationAb();
            _ruleCannotIncludeLetterCombinationCd = new NiceStringRuleCannotIncludeLetterCombinationCd();
            _ruleCannotIncludeLetterCombinationPq = new NiceStringRuleCannotIncludeLetterCombinationPq();
            _ruleCannotIncludeLetterCombinationXy = new NiceStringRuleCannotIncludeLetterCombinationXy();
            _ruleTwoLetterTwiceInARow = new NiceStringRuleLetterTwiceInARow();
            _ruleThreeVowles = new NiceStringRuleThreeVowles();
            _rules = new List<INiceRule> { _ruleCannotIncludeLetterCombinationAb, _ruleCannotIncludeLetterCombinationCd, _ruleCannotIncludeLetterCombinationPq, _ruleCannotIncludeLetterCombinationXy, _ruleTwoLetterTwiceInARow, _ruleThreeVowles };
        }

        [Test]
        public void String_that_match_all_requirements_should_be_a_nice_string()
        {
            _rules = new List<INiceRule> { _ruleCannotIncludeLetterCombinationAb, _ruleCannotIncludeLetterCombinationCd, _ruleCannotIncludeLetterCombinationPq, _ruleCannotIncludeLetterCombinationXy, _ruleTwoLetterTwiceInARow, _ruleThreeVowles };
            var stringToMeetRuleTwiceInARowLetter = "bb";
            var stringToMeetRuleThreeVowels = "aaieoeu";
            _strigToCheck = stringToMeetRuleThreeVowels + stringToMeetRuleTwiceInARowLetter;
            _stringChecker = new StringChecker(_strigToCheck, _rules);

            _stringChecker.IAmNice.Should().BeTrue();

        }

        //TODO mer tester som testar alla regler för stringchecker
    }
}
