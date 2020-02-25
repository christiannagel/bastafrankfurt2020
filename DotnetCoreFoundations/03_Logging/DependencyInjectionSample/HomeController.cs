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

        public HomeController(IHelloService helloService, ILogger<HomeController> logger)
        {
            _helloService = helloService;
            _logger = logger;
        }
        public string Index(string name)
        {
            _logger.LogInformation("Index called");
            return _helloService.Greet(name).ToUpper();
        }
    }
}
