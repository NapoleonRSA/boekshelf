using Dapper;
using grootboekrak.domain;
namespace grootboekrak.repository
{ 

    public class BookRepository : RepositoryBase
    {
        public void Create(Bookdomain book)
        {
            var sql = @"INSERT INTO book 
                        (title, author)
                        VALUES
                        (@Title, @Author)";

            _db.Execute(sql, book);
        }
    }
}