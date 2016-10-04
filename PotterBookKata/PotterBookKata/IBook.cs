using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookKata
{
   public interface IBook
    {
        int PriceEUR { get; set; }
        string Title { get; set; }
        int BookId { get; set; }
    }
}
