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
                        (title, author, genres, date)
                        VALUES
                        (@Title, @Author, @Genres, @Published )";

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
                        author = @author,
                        genres = @genres,
                        date = @date
                        WHERE id = @id";
            _db.Execute(sql, book_data.FromDomain(book));
        }

        public void Delete(int id)
        {
            var sql = @"Delete FROM book 
                        WHERE id = @id";
            _db.Execute(sql, new{id});
        }
    }
}

