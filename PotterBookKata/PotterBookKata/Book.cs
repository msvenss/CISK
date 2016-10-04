using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterBookKata
{
    public class Book : IBook
    {
        public int PriceEUR { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }

        public Book(string title, int id)
        {
            PriceEUR = 8;
            Title = title;
            BookId = id;
        }
    }
}
