using grootboekrak.domain;

namespace grootboekrak.Models
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book ToDomain()
        {
            return new Book
            {
                Title = Title,
                Author = Author
            };
        }
    }
}