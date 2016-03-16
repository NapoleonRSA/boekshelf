using System.Collections.Generic;
using System.Linq;
using Dapper;
using grootboekrak.data;
using grootboekrak.domain;
namespace grootboekrak.repository
{
    public class BookRepository: RepositoryBase
    {
        public void Create(Book book)
        {
            var sql = @"INSERT INTO book 
                        (title, author)
                        VALUES
                        (@Title, @Author)";

            _db.Execute(sql, book);
        }

        public List<Book> GetMany()
        {
            var sql = @"SELECT * FROM book";

            var books_data = _db.Query<book_data>(sql);

            return books_data.Select(book=>book.ToDomain()).ToList();
        } 
    }
}
