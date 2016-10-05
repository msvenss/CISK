using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata.DiscountRules
{
   public class DiscountRuleNoDiscount : IDiscountRule
    {
       public decimal DiscountPercent { get; }
       public bool CanBeUsed(Purchase purchase)
       {
            return purchase.ItemRows.Count() <= 1;
        }

       public int Order => 100;
    }
}
