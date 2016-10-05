using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata.DiscountRules
{
    public class DiscountRuleFiveDifferentBooks : IDiscountRule
    {
        public decimal DiscountPercent => 0.25m;
        public bool CanBeUsed(Purchase purchase)
        {
            return purchase.ItemRows.Count() >= 5;
        }

        public int Order => 10;
    }
}
