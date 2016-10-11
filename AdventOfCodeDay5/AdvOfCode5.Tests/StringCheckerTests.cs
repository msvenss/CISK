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
        private string _stringToCheck;
        private IEnumerable<INiceRule> _rules;
        private NiceStringRuleCannotIncludeLetterCombinationAb _ruleCannotIncludeLetterCombinationAb;
        private NiceStringRuleCannotIncludeLetterCombinationCd _ruleCannotIncludeLetterCombinationCd;
        private NiceStringRuleCannotIncludeLetterCombinationPq _ruleCannotIncludeLetterCombinationPq;
        private NiceStringRuleCannotIncludeLetterCombinationXy _ruleCannotIncludeLetterCombinationXy;
        private NiceStringRuleLetterTwiceInARow _ruleTwoLetterTwiceInARow;
        private NiceStringRuleThreeVowles _ruleThreeVowles;
        private string _stringToMeetRuleTwiceInARowLetter;
        private string _stringToMeetRuleThreeVowels;
        private string _stringContainsAb;
        private string _stringContainsCd;
        private string _stringContainsPq;
        private string _stringContainsXy;

        [SetUp]
        public void SetUp()
        {
            _stringChecker = new StringChecker(_stringToCheck, _rules);
            _ruleCannotIncludeLetterCombinationAb = new NiceStringRuleCannotIncludeLetterCombinationAb();
            _ruleCannotIncludeLetterCombinationCd = new NiceStringRuleCannotIncludeLetterCombinationCd();
            _ruleCannotIncludeLetterCombinationPq = new NiceStringRuleCannotIncludeLetterCombinationPq();
            _ruleCannotIncludeLetterCombinationXy = new NiceStringRuleCannotIncludeLetterCombinationXy();
            _ruleTwoLetterTwiceInARow = new NiceStringRuleLetterTwiceInARow();
            _ruleThreeVowles = new NiceStringRuleThreeVowles();
            _rules = new List<INiceRule>
            {
                _ruleCannotIncludeLetterCombinationAb,
                _ruleCannotIncludeLetterCombinationCd,
                _ruleCannotIncludeLetterCombinationPq,
                _ruleCannotIncludeLetterCombinationXy,
                _ruleTwoLetterTwiceInARow,
                _ruleThreeVowles
            };
            _stringToMeetRuleTwiceInARowLetter = "bb";
            _stringToMeetRuleThreeVowels = "aaieoeu";
            _stringContainsAb = "ab";
            _stringContainsCd = "cd";
            _stringContainsPq = "pq";
            _stringContainsXy = "xy";
        }

        [Test]
        public void String_that_match_all_requirements_should_be_a_nice_string()
        {
            _stringToCheck = _stringToMeetRuleThreeVowels + _stringToMeetRuleTwiceInARowLetter;
            _stringChecker = new StringChecker(_stringToCheck, _rules);
            _stringChecker.IAmNice.Should().BeTrue();
        }

        [Test]
        public void String_without_vowels_should_not_be_nice()
        {
            _stringToCheck = _stringToMeetRuleTwiceInARowLetter;
            _stringChecker = new StringChecker(_stringToCheck, new List<INiceRule> {_ruleThreeVowles});

            _stringChecker.IAmNice.Should().BeFalse();
        }

        [Test]
        public void String_without_two_alike_letters_in_a_row_should_not_be_nice()
        {
            _stringToCheck = _stringContainsAb;
            _stringChecker = new StringChecker(_stringToCheck, _rules);
            _stringChecker.IAmNice.Should().BeFalse();
        }

        [Test]
        public void String_with_wrong_combination_letters_should_not_be_nice()
        {
            _stringToCheck = _stringToMeetRuleThreeVowels + _stringToMeetRuleTwiceInARowLetter + _stringContainsPq;
            _stringChecker = new StringChecker(_stringToCheck, _rules);
            _stringChecker.IAmNice.Should().BeFalse();
        }
    }
}