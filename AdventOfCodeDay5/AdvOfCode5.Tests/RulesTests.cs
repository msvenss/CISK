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
    public class RulesTests
    {
        private INiceRule _rule;

        [Test]
        public void Two_letters_in_a_row_should_be_allowed_as_substring_in_rule()
        {
           _rule = new NiceStringRuleLetterTwiceInARow();
            _rule.SubStringIsAllowed("hejja").Should().BeTrue();

        }

        [Test]
        public void Not_having_two_letters_in_a_row_should_not_be_allowed_as_substring_in_rule()
        {
            _rule = new NiceStringRuleLetterTwiceInARow();
            _rule.SubStringIsAllowed("heja").Should().BeFalse();

        }

        [Test]
        public void Three_vowels_in_a_string_should_allow_nice_string()
        {
            _rule = new NiceStringRuleThreeVowles();
            _rule.SubStringIsAllowed("aioos").Should().BeTrue();
        }

        [Test]
        public void Not_having_three_vowels_should_not_allow_nice_string()
        {
            _rule = new NiceStringRuleThreeVowles();
            _rule.SubStringIsAllowed("bb").Should().BeFalse();
        }

        [Test]
        public void Nice_string_cannot_include_lettercombination_ab()
        {
            _rule = new NiceStringRuleCannotIncludeLetterCombinationAb();
            _rule.SubStringIsAllowed("gesfdsab").Should().BeFalse();
        }

        [Test]
        public void Nice_string_can_include_string_without_lettercombination_ab()
        {
            _rule = new NiceStringRuleCannotIncludeLetterCombinationAb();
            _rule.SubStringIsAllowed("hejhejhej").Should().BeTrue();
        }

        [Test]
        public void Nice_string_cannot_include_lettercombination_cd()
        {
            _rule = new NiceStringRuleCannotIncludeLetterCombinationCd();
            _rule.SubStringIsAllowed("tralalcdal").Should().BeFalse();
        }

        [Test]
        public void Nice_string_cannot_include_lettercombination_pq()
        {
            _rule = new NiceStringRuleCannotIncludeLetterCombinationPq();
            _rule.SubStringIsAllowed("tralapqdal").Should().BeFalse();
        }

        [Test]
        public void Nice_string_cannot_include_lettercombination_xy()
        {
            _rule = new NiceStringRuleCannotIncludeLetterCombinationPq();
            _rule.SubStringIsAllowed("tralapqdxyal").Should().BeFalse();
        }
    }
}
