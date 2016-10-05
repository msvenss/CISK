using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using HPKata.Calculator;
using HPKata.DiscountRules;

namespace HPKata.Tests
{
    [TestFixture]
   public  class CalculatorTests 
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
        private IEnumerable<PurchaseItem> _itemListWithDuplicates;
        private IEnumerable<PurchaseItem> _itemListWithEmptyRows;
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
            _allDiscountRules = new List<IDiscountRule> { _discountRuleFive, _discountRuleFour, _discountRuleThree, _discountRuleTwo }.OrderBy(x => x.Order);
            _itemListWithDuplicates = new List<PurchaseItem> { new PurchaseItem(_bookOne, 1), new PurchaseItem(_bookThree, 0), new PurchaseItem(_bookOne, 1), new PurchaseItem(_bookTwo, 1), new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookTwo, 1), new PurchaseItem(_bookTwo, 1) };
            _itemListWithEmptyRows = new List<PurchaseItem> { new PurchaseItem(_bookOne, 0),  new PurchaseItem(_bookTwo, 1), new PurchaseItem(_bookFour, 1)};
        }

        [Test]
        public void Purchase_should_group_list_items()
        {
            var purchaseList = new Purchase(_itemListWithDuplicates).ItemRows;
            purchaseList.Count().Should().Be(3);
        }

        [Test]
        public void Purchase_should_remove_items_with_count0()
        {
            var purchaseList = new Purchase(_itemListWithEmptyRows).ItemRows;
            purchaseList.Count().Should().Be(2);
        }

        [Test]
        public void Purchase_with_2_different_and_3_different_should_apply_2_discounts()
        {
            var purchase =
                      new Purchase(new List<PurchaseItem> { new PurchaseItem(_bookFour, 3), new PurchaseItem(_bookFive, 3), new PurchaseItem(_bookOne, 2), new PurchaseItem(_bookTwo, 2) });
            _calculator = new DiscountCalculator(purchase,  _allDiscountRules );
            var totCostForDiscount4 = (8*0.8m)*8;
            var totCostForDiscount2 = (8*0.95m)*2;
            _calculator.CalculatedAmount.Should().Be(totCostForDiscount2+totCostForDiscount4);
        }
    }
}
