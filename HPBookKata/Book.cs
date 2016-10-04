using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata
{
    public class Book : IBook
    {
        public int PriceEUR { get; set; }
        public string Title { get; set; }
   

        public Book(string title)
        {
            PriceEUR = 8;
            Title = title;
        }
    }
}
