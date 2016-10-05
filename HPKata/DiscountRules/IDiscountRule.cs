using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPKata.DiscountRules
{
   public interface IDiscountRule
    {
        decimal DiscountPercent { get; }
        bool CanBeUsed(Purchase purchase);
        int Order { get; }
    }
}
