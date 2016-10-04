using System;
using System.Linq;

namespace HPBookKata.DiscountRules
{
   public class DiscountRuleFourDifferentBooks: IDiscountRule
   {
       public decimal DiscountPercent => 0.2m;
       public bool CanBeUsed(Purchase purchase)
       {
            return purchase.ItemRows.Count() >= 4;
        }
    }
}
