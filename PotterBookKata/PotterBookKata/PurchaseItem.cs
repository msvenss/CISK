using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookKata
{
    public class PurchaseItem
    {
        public Book ItemToBuy { get; set; }
        public int NrOfItems { get; set; }
        
        public PurchaseItem(Book itemToBuy, int nrOfItems)
        {
            ItemToBuy = itemToBuy;
            NrOfItems = nrOfItems;

        }
    }
}
