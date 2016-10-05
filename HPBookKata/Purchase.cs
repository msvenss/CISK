using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata
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
            //TODO ifsats på en ngn grupp är mer än två, annars returnera samma lista

            List<PurchaseItem> checkingItemList = itemRows.OrderBy(b => b.ItemToBuy.Title).ToList();
            var newGroupedItemList = new List<PurchaseItem>();
            if (checkingItemList.Count() > 0 || checkingItemList != null)
            {
                bool checkMoreItems = checkingItemList.Count() > 0;
                while (checkMoreItems)
                {
                    var elementToCheck = itemRows.ElementAt(0).ItemToBuy.Title;
                    var indexToBreak = 0;
                    if (checkingItemList.Count() > 1) { 
                    indexToBreak =
                        checkingItemList.IndexOf(checkingItemList.Skip(1).Last(b => b.ItemToBuy.Title == elementToCheck));
                    }

                    if (indexToBreak > 0)
                    {
                        var newNrOfItems = 0;
                        IBook elementToAdd = checkingItemList.ElementAt(0).ItemToBuy;

                        for (int i = 0; i <= indexToBreak; i++)
                        {
                            newNrOfItems += checkingItemList.ElementAt(i).NrOfItems;
                            elementToAdd = checkingItemList.ElementAt(i).ItemToBuy;
                        }
                        newGroupedItemList.Add(new PurchaseItem(elementToAdd, newNrOfItems));
                        checkingItemList.RemoveRange(0, indexToBreak + 1);

                    }
                    else
                    {
                        newGroupedItemList.Add(checkingItemList.ElementAt(0));
                        checkingItemList.RemoveAt(0);
                    }
                    checkMoreItems = checkingItemList.Count() > 0;
                }
            }
            else
            {
                newGroupedItemList = itemRows.ToList();
            }
            return newGroupedItemList;
        }

        //TODO: add groupedList Method  public IEnumerable<PurchaseItem> GroupItemRows(IEnumerable<PurchaseItem> itemRows)
    }
}