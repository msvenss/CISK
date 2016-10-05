using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPKata
{
   public interface IBook
    {
        int PriceEUR { get; set; }
        string Title { get; set; }
    }
}
