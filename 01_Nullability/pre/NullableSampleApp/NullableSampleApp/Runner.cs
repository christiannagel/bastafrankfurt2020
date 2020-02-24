using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableSampleApp
{
    public class Runner
    {
        private readonly BooksContext _booksContext;
        public Runner(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }
        public async Task CreateDatabaseAsync()
        {
            bool created = await _booksContext.Database.EnsureCreatedAsync();
            Console.WriteLine($"database created: {created}");
        }

        public void ShowBooks()
        {
            var books = _booksContext.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title.ToUpper()} {book.Publisher.ToUpper()}");
            }
        }
    }
}
