using System.Collections.Generic;
using grootboekrak.domain;

namespace grootboekrak.Models
{
    public class BookIndexModel
    {
        public List<BookModel> Books { get; set; }

        public static BookIndexModel FromDomain(List<Book> books)
        {
            var booksModel = new List<BookModel>();
            foreach (var book in books)
            {
                booksModel.Add(new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author
                });
            }

            return new BookIndexModel{Books = booksModel};
        }
    }
}