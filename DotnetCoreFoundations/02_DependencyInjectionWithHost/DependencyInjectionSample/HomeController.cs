using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HomeController
    {
        private readonly IHelloService _helloService;

        public HomeController(IHelloService helloService)
        {
            _helloService = helloService;
        }
        public string Index(string name)
        {
            return _helloService.Greet(name).ToUpper();
        }
    }
}
