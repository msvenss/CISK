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


        [SetUp]
        public void SetUt()
        {
            _bookOne = new Book("HP och de vises sten");
            _bookThree = new Book("HP och hemligheternas kammare");
            _bookThree = new Book("HP och fången från Azkaban");
            _bookFour = new Book("HP och den flammande bägaren");
            _bookFive = new Book("Hp och Fenixordern");
        
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
            _calculator= new DiscountCalculator(purchase, _discountRuleTwo);
            _calculator.Calculate().Should().Be(15.2m);
        }

        [Test]
        public void Three_different_books_should_give_10percent_discount()
        {
            var purchase =
            new Purchase(new List<PurchaseItem> { new PurchaseItem(_bookFour, 1), new PurchaseItem(_bookFive, 1), new PurchaseItem(_bookOne, 1) });
            _discountRuleThree = new DiscountRuleThreeDifferentBooks(); 
            _calculator = new DiscountCalculator(purchase, _discountRuleThree);
            _calculator.Calculate().Should().Be(21.6m);
        }
        //three different books should give 10percent discount
    }
}
