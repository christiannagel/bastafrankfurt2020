using NullableSampleApp;
using System;

namespace ChangeNotificationClient
{
    class Book : BindableBase
    {
        private int _id;
        public int Id 
        { 
            get => _id; 
            set => SetProperty(ref _id, value); 
        }

        private string _title = string.Empty;
        public string Title 
        {
            get => _title;
            set => SetProperty(ref _title, value); 
        }

        private string? _publisher;

        public string? Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }

    }

    class Program
    {
        static void Main()
        {
            var book = new Book { Id = 1, Title = "Professional C#", Publisher = "Wrox Press" };
            book.PropertyChanged += (sender, e) =>
            {
                if (sender is Book book)
                {
                    Console.WriteLine($"{e.PropertyName} changed");
                }
                
            };
            book.Id = 42;
            book.Title = "C# 8 Updates";
            book.Publisher = null;
        }
    }
}
