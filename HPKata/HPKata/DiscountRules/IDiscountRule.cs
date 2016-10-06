namespace HPKata.DiscountRules
{
   public interface IDiscountRule
    {
        decimal DiscountPercent { get; }
        bool CanBeUsed(Purchase purchase);
        int Order { get; }
    }
}
