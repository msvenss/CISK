using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata
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
