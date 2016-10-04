using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPBookKata.DiscountRules;

namespace HPBookKata.Calculator
{
   public class DiscountCalculator: IDiscountCalculator
   {

       private Purchase _purchase;
       private IDiscountRule _discountRule;

       public DiscountCalculator(Purchase purchase, IDiscountRule discountRule)
       {
           _purchase = purchase;
           _discountRule = discountRule;

       }
       public decimal Calculate()
       {
           decimal amount = 0;
           if (_discountRule.CanBeUsed(_purchase))
           {
                List<PurchaseItem> checkDiscountList = _purchase.ItemRows.OrderByDescending(ir => ir.NrOfItems).ToList();
                bool listHasItems = checkDiscountList.Count > 1;

                while (listHasItems)
                {
                    var firstItemCount = checkDiscountList.First().NrOfItems;
                    var secontItemCount = checkDiscountList.Skip(1).First().NrOfItems;
                    var itemsWithOriginalPrice = firstItemCount - secontItemCount;
                    amount += checkDiscountList.First().ItemToBuy.PriceEUR * itemsWithOriginalPrice;
                    amount += (checkDiscountList.First().ItemToBuy.PriceEUR * (firstItemCount - itemsWithOriginalPrice)) * (1 - _discountRule.DiscountPercent);
                  //  var test = 1 - _discountRule.DiscountPercent;
                   amount += checkDiscountList.Skip(1).First().ItemToBuy.PriceEUR * (1 - _discountRule.DiscountPercent);
                    checkDiscountList.RemoveRange(0, 2);
                    if (checkDiscountList.Count == 1)
                    {
                        itemsWithOriginalPrice = secontItemCount - checkDiscountList.First().NrOfItems;
                        amount += checkDiscountList.First().ItemToBuy.PriceEUR * itemsWithOriginalPrice;
                        amount += (checkDiscountList.First().ItemToBuy.PriceEUR * (secontItemCount - itemsWithOriginalPrice)) * (1 - _discountRule.DiscountPercent);
                        checkDiscountList.RemoveAt(0);
                    }

                    if (checkDiscountList.Count == 0)
                    {
                        listHasItems = false;
                    }
                }
            }
           return amount;
       }
        }
}
