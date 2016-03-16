using grootboekrak.domain;

namespace grootboekrak.data
{
    public class book_data
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public Book ToDomain()
        {
            return new Book
            {
                Id = id,
                Title = title,
                Author = author
            };
        }
    }
}
