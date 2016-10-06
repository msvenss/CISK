

namespace HPKata
{
    public class PurchaseItem
    {
        public IBook ItemToBuy { get; set; }
        public int NrOfItems { get; set; }

        public PurchaseItem(IBook itemToBuy, int nrOfItems)
        {
            ItemToBuy = itemToBuy;
            NrOfItems = nrOfItems;
        }
    }
}
