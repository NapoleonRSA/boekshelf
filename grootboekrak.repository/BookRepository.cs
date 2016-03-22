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

        public Book Get(int id)
        {
            var sql = @"SELECT * FROM book
                            WHERE id = @id";

            var book_data = _db.Query<book_data>(sql, new {id}).First();

            return book_data.ToDomain();

        }

        public void Update(Book book)
        {
            var sql = @"UPDATE book SET 
                        title = @title,
                        author = @author
                        WHERE id = @id";
            _db.Execute(sql, book_data.FromDomain(book));
        }
    }
}

