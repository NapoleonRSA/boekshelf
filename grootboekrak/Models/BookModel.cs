using grootboekrak.domain;

namespace grootboekrak.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genres { get; set; }
        public string Published { get; set; }

        public static BookModel FromDomain(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genres = book.Genres,
                Published = book.Published
            };
        }

        public  Book ToDomain()
        {
            return new Book
            {
                Id = Id,
                Title = Title,
                Author = Author,
                Genres = Genres,
                Published = Published
            };
        }
    }
}