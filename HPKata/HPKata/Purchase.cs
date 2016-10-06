using System.Collections.Generic;
using System.Linq;

namespace HPKata
{
    public class Purchase
    {
        public IEnumerable<PurchaseItem> ItemRows { get; set; }

        public Purchase(IEnumerable<PurchaseItem> itemRows)
        {
            ItemRows = GrouPurchaseItems(itemRows);
        }

        public IEnumerable<PurchaseItem> GrouPurchaseItems(IEnumerable<PurchaseItem> itemRows)
        {
            var newGroupedItemList = new List<PurchaseItem>();

            var checkingList = itemRows.GroupBy(x => x.ItemToBuy.Title).ToList();

            if (checkingList.Any(x => x.Count() > 1))
            {
                newGroupedItemList.AddRange(from row in checkingList
                                            let book = row.First().ItemToBuy
                                            let totNrOfItems = row.Sum(nrOfItems => nrOfItems.NrOfItems)
                                            where totNrOfItems > 0
                                            select new PurchaseItem(book, totNrOfItems));
                return newGroupedItemList;
            }
            else
            {
                var result = itemRows.ToList();
                if (itemRows.Any(x => x.NrOfItems == 0))
                {
                    result.RemoveAll(x => x.NrOfItems == 0);
                }
                return result;
            }
        }
    }
}