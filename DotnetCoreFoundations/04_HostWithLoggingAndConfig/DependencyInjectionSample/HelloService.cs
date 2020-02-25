using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HelloService : IHelloService
    {
        private ILogger _logger;
        public HelloService(ILogger<HelloService> logger)
        {
            _logger = logger;
        }
        public string Greet(string name)
        {
            _logger.LogError("some error occurred");
            return $"Hello, {name}";
        }
    }
}
