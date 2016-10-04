using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterBookKata.DiscountRules;

namespace PotterBookKata.Calculator
{
    public class DiscountCalculator: IDiscountCalculator

    {
       public decimal Calculate(Purchase purchase)
        {
            decimal amount = 0;
            var rule = new TwoDifferentBooksDiscount();
            if (rule.CanBeUsed(purchase))
            {
                var itemsRowsWithOriginalPrice = purchase.ItemRows.Count()%2;

              List<PurchaseItem> checkDiscountList =   purchase.ItemRows.OrderByDescending(ir => ir.NrOfItems).ToList();
                bool listHasItems = checkDiscountList.Count > 1;
                
              while(listHasItems)
                {
                    var firstItemCount =checkDiscountList.First().NrOfItems;
                    var secontItemCount = checkDiscountList.Skip(1).First().NrOfItems;
                    var itemsWithOriginalPrice = firstItemCount - secontItemCount;
                    amount += checkDiscountList.First().ItemToBuy.PriceEUR*itemsWithOriginalPrice;
                    amount += (checkDiscountList.First().ItemToBuy.PriceEUR*(firstItemCount - itemsWithOriginalPrice))* (1-rule.PercentDiscount);
                    var test = 1 - rule.PercentDiscount;
                    amount += checkDiscountList.Skip(1).First().ItemToBuy.PriceEUR*(1 - rule.PercentDiscount);
                    checkDiscountList.RemoveRange(0,2);
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
