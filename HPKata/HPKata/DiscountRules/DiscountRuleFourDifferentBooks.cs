using System.Linq;

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
