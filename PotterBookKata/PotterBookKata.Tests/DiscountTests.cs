using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using PotterBookKata.Calculator;

namespace PotterBookKata.Tests
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

        [SetUp]
        public void SetUp()
        {
            _bookOne = new Book("HP och de vises sten", 1);
            _bookThree = new Book("HP och hemligheternas kammare", 2);
            _bookThree = new Book("HP och fången från Azkaban", 3);
            _bookFour = new Book("HP och den flammande bägaren", 4);
            _bookFive  = new Book("Hp och Fenixordern", 5);
        }
     

        [Test]
        public void One_book_should_cost_8_euros()
        {
           _bookOne.PriceEUR.Should().Be(8);

        }

        [Test]
        public void Should_group_items_in_purchase()
        {
            IEnumerable<PurchaseItem> purchaseList = new List<PurchaseItem>
           { new PurchaseItem(_bookThree,2), new PurchaseItem(_bookFive,1), new PurchaseItem(_bookFive, 3)};
            var purchase = new Purchase(purchaseList);
            var result = purchase.GroupItemRows(purchaseList);
            result.Count().Should().Be(2);

        }

        [Test]
        public void Two_different_books_should_give_5percent_discount()
        {
           IEnumerable<PurchaseItem> purchaseList = new List<PurchaseItem>
           { new PurchaseItem(_bookThree,1), new PurchaseItem(_bookFive,1)};
            var purchase = new Purchase(purchaseList);
            _calculator = new DiscountCalculator();
            _calculator.Calculate(purchase).Should().Be(15.2m);
        }

        [Test]
        public void Two_different_books_should_give_5percent_discount_on_two_of_three_books()
        {
            IEnumerable<PurchaseItem> purchaseList = new List<PurchaseItem>
           { new PurchaseItem(_bookThree,2), new PurchaseItem(_bookFive,1)};
            var purchase = new Purchase(purchaseList);
            _calculator = new DiscountCalculator();
            _calculator.Calculate(purchase).Should().Be(23.2m);
         }

        //three different books should give 10percent discount
        //four different books should give 20percent discount
        // five different books should give 25percent discount

        // test- DET SKA GÅ ATT SKICKA IN TRE RADER I KALKYLATOREN
        //TEST LISTAN SKA GRUPPERA SIG

    }
}
