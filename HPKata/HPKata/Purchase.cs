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
                foreach (var row in checkingList)
                {
                    var book = row.First().ItemToBuy;
                    var totNrOfItems = row.Sum(nrOfItems => nrOfItems.NrOfItems);
                    if (totNrOfItems <= 0) continue;
                    var itemToAdd = new PurchaseItem(book,totNrOfItems);
                    newGroupedItemList.Add(itemToAdd);
                }
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
