using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPBookKata.DiscountRules;

namespace HPBookKata.Calculator
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private Purchase _purchase;
        private IEnumerable<IDiscountRule> _discountRules;

        public DiscountCalculator(Purchase purchase, IEnumerable<IDiscountRule> discountRules)
        {
            _purchase = purchase;
            _discountRules = discountRules;
        }

        public decimal Calculate()
        {
            decimal amount = 0;
           
                IDiscountRule currentDiscountRule;
                List<PurchaseItem> checkDiscountList = _purchase.ItemRows.OrderByDescending(ir => ir.NrOfItems).ToList();
                bool listHasItems = checkDiscountList.Count > 1;
                var lastNrOfItemsComparation = 0;


                while (listHasItems)
                {
                    checkDiscountList.RemoveAll(x => x.NrOfItems == 0);
                    currentDiscountRule = _discountRules.First(r => r.CanBeUsed(new Purchase(checkDiscountList)));
                    var currentNrOFItems = checkDiscountList.First().NrOfItems;
                    var indexToBreak =
                        checkDiscountList.IndexOf(checkDiscountList.Skip(1).Last(i => i.NrOfItems == currentNrOFItems));

                    if (indexToBreak != null || indexToBreak == 0)
                    {
                        for (int i = 0; i <= indexToBreak; i++)
                        {
                            lastNrOfItemsComparation = checkDiscountList.ElementAt(indexToBreak).NrOfItems;
                            var itemPrice = checkDiscountList.ElementAt(i).ItemToBuy.PriceEUR;
                            amount += itemPrice*(1 - currentDiscountRule.DiscountPercent);
                            checkDiscountList.ElementAt(i).NrOfItems -= 1; 
                        }

                        checkDiscountList.RemoveAll(x => x.NrOfItems == 0);
                    }

                    else
                    {
                        var itemPrice = checkDiscountList.ElementAt(0).ItemToBuy.PriceEUR;
                        var itemsWithOriginalPrice = lastNrOfItemsComparation - checkDiscountList.ElementAt(0).NrOfItems;
                        amount += itemPrice*(1 - currentDiscountRule.DiscountPercent);
                        lastNrOfItemsComparation = checkDiscountList.ElementAt(0).NrOfItems;
                        checkDiscountList.RemoveAt(0);
                    }

                    if (checkDiscountList.Count == 0)
                    {
                        listHasItems = false;
                        break;
                    }
                }

            //if (_discountRules.CanBeUsed(_purchase))
            //{

            //  var nrOfDiscountedItems = currentNrOFItems*(indexToBreak + 1);
            //  lastNrOfItemsComparation = checkDiscountList.ElementAt(indexToBreak).NrOfItems;

            //checkDiscountList.RemoveRange(0, indexToBreak);
            //if (checkDiscountList.First().NrOfItems == checkDiscountList.Skip(1).First().NrOfItems)
            //{

            //}

            //while (listHasItems)
            //{
            //    var firstItemCount = checkDiscountList.First().NrOfItems;
            //    var secontItemCount = checkDiscountList.Skip(1).First().NrOfItems;
            //    var itemsWithOriginalPrice = firstItemCount - secontItemCount;
            //    amount += checkDiscountList.First().ItemToBuy.PriceEUR * itemsWithOriginalPrice;
            //    amount += (checkDiscountList.First().ItemToBuy.PriceEUR * (firstItemCount - itemsWithOriginalPrice)) * (1 - currentDiscountRule.DiscountPercent);
            //  //  var test = 1 - _discountRule.DiscountPercent;
            //   amount += checkDiscountList.Skip(1).First().ItemToBuy.PriceEUR * (1 - currentDiscountRule.DiscountPercent);
            //    checkDiscountList.RemoveRange(0, 2);
            //    if (checkDiscountList.Count == 1)
            //    {
            //        itemsWithOriginalPrice = secontItemCount - checkDiscountList.First().NrOfItems;
            //        amount += checkDiscountList.First().ItemToBuy.PriceEUR * itemsWithOriginalPrice;
            //        amount += (checkDiscountList.First().ItemToBuy.PriceEUR * (secontItemCount - itemsWithOriginalPrice)) * (1 - currentDiscountRule.DiscountPercent);
            //        checkDiscountList.RemoveAt(0);
            //    }

            //    if (checkDiscountList.Count == 0)
            //    {
            //        listHasItems = false;
            //    }
            //}
        
            return amount;
        }
    }
}

// applicera på alla items som har samma count. 
// abount = för alla rader item * pris * antal * discoount
// sedan ta minus på alla nr of items för alla rader som kommit bort