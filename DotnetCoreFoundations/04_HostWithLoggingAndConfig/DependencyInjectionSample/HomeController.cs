using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HomeController
    {
        private readonly IHelloService _helloService;
        private readonly ILogger _logger;
        private readonly BooksContext _booksContext;

        public HomeController(BooksContext booksContext, IHelloService helloService, ILogger<HomeController> logger)
        {
            _helloService = helloService;
            _logger = logger;
            _booksContext = booksContext;
        }
        public string Index(string name)
        {
            _logger.LogInformation("Index called");
            return _helloService.Greet(name).ToUpper();
        }

        public void CreateDatabase()
        {
            bool created = _booksContext.Database.EnsureCreated();
        }
    }
}
