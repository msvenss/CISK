using System.Collections.Generic;

namespace PotterBookKata.DiscountRules
{
    public  interface IDiscountRule
    {
         decimal PercentDiscount { get;}
        bool CanBeUsed(Purchase purchase);

    }
}
