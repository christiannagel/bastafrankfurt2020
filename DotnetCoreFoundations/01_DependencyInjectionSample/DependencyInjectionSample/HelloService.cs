using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HelloService : IHelloService
    {
        public string Greet(string name) => $"Hello, {name}";
    }
}
