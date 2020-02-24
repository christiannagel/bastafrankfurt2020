using Microsoft.EntityFrameworkCore;

namespace NullableSampleApp
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Book[] books =
            {
                new Book("Professional C# 6 and .NET Core 1") { BookId = 1, Publisher = "Wrox Press"},
                new Book("C# 8 and .NET Core 3 Updates") { BookId = 2 },
                new Book("Professional C# and .NET 5") { BookId = 3, Publisher = "Wrox Press"},

            };
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
