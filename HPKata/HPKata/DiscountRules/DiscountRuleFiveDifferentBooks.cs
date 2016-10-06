using System.Linq;

namespace HPKata.DiscountRules
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
