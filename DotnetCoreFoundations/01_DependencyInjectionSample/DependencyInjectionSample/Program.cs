using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IHelloService, HelloService>();
            services.AddTransient<HomeController>();
            using var container = services.BuildServiceProvider();

            var controller = container.GetService<HomeController>();
            var result =controller.Index("Stephanie");
            Console.WriteLine(result);
        }
    }
}
