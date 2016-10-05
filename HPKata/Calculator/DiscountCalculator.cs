using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPKata.DiscountRules;

namespace HPKata.Calculator
{
    public class DiscountCalculator :ICalculator
    {
        public decimal CalculatedAmount { get { return Calculate(_purchase, _rules); } }
        private Purchase _purchase;
        private IEnumerable<IDiscountRule> _rules;

        public DiscountCalculator(Purchase purchase, IEnumerable<IDiscountRule> rules )
        {
            _purchase = purchase;
            _rules = rules;
        }

        public decimal Calculate(Purchase purchase, IEnumerable<IDiscountRule> rules)
        {
            decimal amount = 0;
            List<PurchaseItem> checkDiscountList = purchase.ItemRows.OrderByDescending(ir => ir.NrOfItems).ToList();
            bool listHasItems = checkDiscountList.Count > 1;

            while (listHasItems)
            {
 
                IDiscountRule currentDiscountRule =
                    rules.First(r => r.CanBeUsed(new Purchase(checkDiscountList)));
                var nrOfItemsFirstItemRowComparer = checkDiscountList.First().NrOfItems;

                var indexOfLastElementWithSameNumber = 0;
                var nextAmountOfItemsChecker = 0;
                try
                {
                    indexOfLastElementWithSameNumber =
                        checkDiscountList.IndexOf(checkDiscountList.Skip(1).Last(i => i.NrOfItems == nrOfItemsFirstItemRowComparer));
                }
                catch (Exception)
                {
                    indexOfLastElementWithSameNumber = 0;
                }
                if (checkDiscountList.Count > (indexOfLastElementWithSameNumber + 1))
                {
                    nextAmountOfItemsChecker = checkDiscountList.ElementAt(indexOfLastElementWithSameNumber + 1).NrOfItems;
                }

                if (indexOfLastElementWithSameNumber > 0)
                {
                    List<PurchaseItem> tempListForCheckCurrentRule = new List<PurchaseItem>();
                    for (int i = 0; i <= indexOfLastElementWithSameNumber; i++)
                    {
                        tempListForCheckCurrentRule.Add(checkDiscountList.ElementAt(i));
                     }

                    currentDiscountRule =
                   rules.First(r => r.CanBeUsed(new Purchase(tempListForCheckCurrentRule)));
                    for (int i = 0; i <= indexOfLastElementWithSameNumber; i++)
                    {
                        var itemPrice = checkDiscountList.ElementAt(i).ItemToBuy.PriceEUR;
                        amount += itemPrice * (1 - currentDiscountRule.DiscountPercent);
                        checkDiscountList.ElementAt(i).NrOfItems -= 1;
                    }
                    checkDiscountList.RemoveAll(x => x.NrOfItems == 0);
                    //   checkDiscountList.RemoveRange(0, indexOfLastElementWithSameNumber + 1); // Jo, den ska va här /kan va
                }

                else if (indexOfLastElementWithSameNumber == 0)
                {
                    var itemPrice = checkDiscountList.ElementAt(0).ItemToBuy.PriceEUR;
                    var itemsWithOriginalPrice = checkDiscountList.ElementAt(0).NrOfItems - nextAmountOfItemsChecker;
                    amount += itemsWithOriginalPrice * itemPrice;
                    // amount += itemPrice*(1 - currentDiscountRule.DiscountPercent);
                    ///     nrOfItemsFirstItemRowComparer = checkDiscountList.ElementAt(0).NrOfItems; //
                    //  checkDiscountList.RemoveAt(0);
                    checkDiscountList.ElementAt(0).NrOfItems -= itemsWithOriginalPrice;
                }
                if (checkDiscountList.Count == 0)
                {
                    listHasItems = false;
                    break;
                }
            }
            return amount;
        }


    }
}
