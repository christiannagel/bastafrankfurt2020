using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IHelloService, HelloService>();
                    services.AddTransient<HomeController>();
                }).UseWindowsService()
                .Build().


            var controller = host.Services.GetService<HomeController>();
            var result =controller.Index("Stephanie");
            Console.WriteLine(result);
        }
    }
}
