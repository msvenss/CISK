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

          List<IGrouping<string, PurchaseItem>> checkingList = itemRows.GroupBy(x => x.ItemToBuy.Title).ToList();

            if (checkingList.Any(x => x.Count() > 1))
            {
                foreach (var row in checkingList)
                {
                    int totNrOfItems = 0;
                    var book = row.First().ItemToBuy;
                    foreach (var nrOfItems in row)
                    {    
                        totNrOfItems += nrOfItems.NrOfItems;
                    }
                    if (totNrOfItems > 0) { 
                    PurchaseItem itemToAdd = new PurchaseItem(book,totNrOfItems);
                    newGroupedItemList.Add(itemToAdd);
                        }
                }
                return newGroupedItemList;
            }
            else
            {
                List<PurchaseItem> result = itemRows.ToList();
                if (itemRows.Any(x => x.NrOfItems == 0))
                {
                   result.RemoveAll(x => x.NrOfItems == 0);
                }
                return result;
            }
            
        }
    }
}
