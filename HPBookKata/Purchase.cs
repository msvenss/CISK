using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata
{
    public class Purchase
    {
        public IEnumerable<PurchaseItem> ItemRows { get; set; }

        public Purchase(IEnumerable<PurchaseItem> itemRows)
        {
            ItemRows = itemRows;
        }

        //TODO: add groupedList Method  public IEnumerable<PurchaseItem> GroupItemRows(IEnumerable<PurchaseItem> itemRows)

    }
}
