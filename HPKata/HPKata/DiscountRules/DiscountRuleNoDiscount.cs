using System.Linq;


namespace HPKata.DiscountRules
{
   public class DiscountRuleNoDiscount :IDiscountRule
   {
       public decimal DiscountPercent => 0.0m;
       public bool CanBeUsed(Purchase purchase)
       {
           return true;
       }

       public int Order => 100;
   }
}
