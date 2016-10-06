
namespace HPKata
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
