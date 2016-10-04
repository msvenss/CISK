using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookKata
{
    public class Purchase
    {
        public Purchase(IEnumerable<PurchaseItem> itemRows)
        {
            ItemRows = itemRows;
          //  TotalAmount(itemRows);
        }

        public IEnumerable<PurchaseItem> ItemRows { get; set; }

        public IEnumerable<PurchaseItem> GroupItemRows(IEnumerable<PurchaseItem> itemRows)
        {
            itemRows = itemRows.ToList();
            var groupedList = itemRows.GroupBy(x => x.ItemToBuy);
           var testDupList = groupedList.Select(d => d.Count() > 1);
            var testSingList = groupedList.Select(s => s.Count() = 1);
             

            /////få alla diubbletter
            /// //radera alla dubletter
            /// //slå ihop alla dubletter
            /// //lägg till alla dubletter
           
            var groupedItemRows = new List<PurchaseItem>();
            var duplicateBooks = itemRows.GroupBy(x => x.ItemToBuy, x => x.NrOfItems);
    
            return groupedItemRows;

        }


          
        }
              

    }

