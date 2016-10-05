using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPKata.DiscountRules
{
    public class DiscountRuleFourDifferentBooks : IDiscountRule
    {
        public decimal DiscountPercent => 0.2m;
        public bool CanBeUsed(Purchase purchase)
        {
            return purchase.ItemRows.Count() >= 4;
        }

        public int Order => 20;
    }
}
