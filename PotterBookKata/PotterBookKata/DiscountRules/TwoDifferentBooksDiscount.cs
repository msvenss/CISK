using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookKata.DiscountRules
{
    public class TwoDifferentBooksDiscount : IDiscountRule
    {

        public decimal PercentDiscount => 0.05m;
    
        public bool CanBeUsed(Purchase purchase)
        {
            return purchase.ItemRows.Count() >= 2;

        }
    }
}