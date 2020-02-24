using System.ComponentModel.DataAnnotations;

namespace NullableSampleApp
{
    public class Book
    {
        public Book(string title)
            => Title = title;

        public int BookId { get; set; } = -1;

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(20)]
        public string? Publisher { get; set; }
    }
}
