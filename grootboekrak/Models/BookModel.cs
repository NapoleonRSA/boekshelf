using grootboekrak.domain;

namespace grootboekrak.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public static BookModel FromDomain(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
        }
    }
}