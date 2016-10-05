using System;
using System.Collections;
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
    public class DiscountTests
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
        


        [SetUp]
        public void SetUt()
        {
            _bookOne = new Book("HP och de vises sten");
            _bookTwo = new Book("HP och hemligheternas kammare");
            _bookThree = new Book("HP och fången från Azkaban");
            _bookFour = new Book("HP och den flammande bägaren");
            _bookFive = new Book("Hp och Fenixordern");
            _discountRuleTwo = new DiscountRuleTwoDifferentBooks();
            _discountRuleThree = new DiscountRuleThreeDifferentBooks();
            _discountRuleFour= new DiscountRuleFourDifferentBooks();
            _discountRuleFive =new DiscountRuleFiveDifferentBooks();
           
        
        }

        [Test]
        public void One_book_should_cost_8_euros()
        {
            _bookFive.PriceEUR.Should().Be(8);

        }

        [Test]
        public void Two_different_books_should_give_5percent_discount()
        {
            var purchase =
                new Purchase(new List<PurchaseItem> {new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookFive, 1)});
           _discountRuleTwo = new DiscountRuleTwoDifferentBooks();;
            _calculator= new DiscountCalculator(purchase,new List<IDiscountRule>{ _discountRuleTwo });
            _calculator.Calculate().Should().Be(15.2m);
        }

        [Test]
        public void Three_different_books_should_give_10percent_discount()
        {
            var purchase =
            new Purchase(new List<PurchaseItem> { new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookFive, 1), new PurchaseItem(_bookOne, 1) });
            _discountRuleThree = new DiscountRuleThreeDifferentBooks(); 
            _calculator = new DiscountCalculator(purchase, new List<IDiscountRule> { _discountRuleThree});
            _calculator.Calculate().Should().Be(21.6m);
        }

        [Test]
        public void Four_different_books_should_give_20percent_discount()
        {
            var purchase =
            new Purchase(new List<PurchaseItem> { new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookFive, 1), new PurchaseItem(_bookOne, 1), new PurchaseItem(_bookTwo, 1 ) });
            _discountRuleFour = new DiscountRuleFourDifferentBooks();
            _calculator = new DiscountCalculator(purchase, new List<IDiscountRule> { _discountRuleFour});
            _calculator.Calculate().Should().Be(25.6m);
        }

        [Test]
        public void Five_different_books_should_give_25percent_discount()
        {
            var purchase =
            new Purchase(new List<PurchaseItem> { new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookFive, 1), new PurchaseItem(_bookOne, 1), new PurchaseItem(_bookTwo, 1), new PurchaseItem(_bookThree,1) });
            _discountRuleFive = new DiscountRuleFiveDifferentBooks();
            _calculator = new DiscountCalculator(purchase, new List<IDiscountRule> { _discountRuleFive});
            _calculator.Calculate().Should().Be(30.0m);
        }
     
    }
}
