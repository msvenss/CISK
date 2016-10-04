using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;


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
    }
}
