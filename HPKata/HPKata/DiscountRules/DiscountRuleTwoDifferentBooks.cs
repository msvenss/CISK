using System.Linq;


namespace HPKata.DiscountRules
{
   public class DiscountRuleTwoDifferentBooks :IDiscountRule
   {
       public decimal DiscountPercent => 0.05m;
       public bool CanBeUsed(Purchase purchase)
       {
            return purchase.ItemRows.Count() >= 2;
       }

       public int Order => 40;
   }
}
