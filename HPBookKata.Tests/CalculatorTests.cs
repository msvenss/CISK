using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using HPBookKata.Calculator;
using HPBookKata.DiscountRules;

namespace HPBookKata.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Book _bookOne;
        private Book _bookTwo;
        private Book _bookThree;
        private Book _bookFour;
        private Book _bookFive;
        private DiscountCalculator _calculator;
        private DiscountRuleTwoDifferentBooks _discountRuleTwo;
        private DiscountRuleThreeDifferentBooks _discountRuleThree;
        private DiscountRuleFourDifferentBooks _discountRuleFour;
        private DiscountRuleFiveDifferentBooks _discountRuleFive;
        private static IEnumerable<PurchaseItem> _itemListWithDuplicates;
        private IEnumerable<PurchaseItem> _itemListWithDuplicates2;

        private IEnumerable<IDiscountRule> _allDiscountRules;


        [SetUp]
        public void SetUp()
        {
            _bookOne = new Book("HP och de vises sten");
            _bookTwo = new Book("HP och hemligheternas kammare");
            _bookThree = new Book("HP och fången från Azkaban");
            _bookFour = new Book("HP och den flammande bägaren");
            _bookFive = new Book("Hp och Fenixordern");
            _discountRuleTwo = new DiscountRuleTwoDifferentBooks();
            _discountRuleThree = new DiscountRuleThreeDifferentBooks();
            _discountRuleFour = new DiscountRuleFourDifferentBooks();
            _discountRuleFive = new DiscountRuleFiveDifferentBooks();
            _allDiscountRules = new List<IDiscountRule> {_discountRuleFive,_discountRuleFour, _discountRuleThree, _discountRuleTwo}.OrderBy(x => x.Order);
            _itemListWithDuplicates= new List<PurchaseItem> {new PurchaseItem(_bookOne,1), new PurchaseItem(_bookOne,1),new PurchaseItem(_bookTwo,1)};
            _itemListWithDuplicates2 = new List<PurchaseItem> { new PurchaseItem(_bookOne, 1), new PurchaseItem(_bookOne, 1), new PurchaseItem(_bookTwo, 1), new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookTwo, 1), new PurchaseItem(_bookTwo, 1) };

        }

       
        [Test]
        public void Purchase_should_group_list_items()
        {
            var purchaseList = new Purchase(_itemListWithDuplicates2).ItemRows;
            purchaseList.Count().Should().Be(2);
        }

    }
}
