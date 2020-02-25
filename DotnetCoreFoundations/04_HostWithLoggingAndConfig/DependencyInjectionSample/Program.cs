using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddUserSecrets("f0028e10-b711-487c-9dad-7144d7c5ead3");
                })
                .ConfigureLogging(logging =>
                {

                })
                .ConfigureServices((context, services) =>
                {
                    var conn = context.Configuration.GetConnectionString("BooksConnection");
                    services.AddDbContext<BooksContext>(options =>
                    {
                        options.UseSqlServer(conn);
                    });
                    services.AddTransient<IHelloService, HelloService>();
                    services.AddTransient<HomeController>();
                })
                .Build();


            var controller = host.Services.GetService<HomeController>();
            var result =controller.Index("Stephanie");
            controller.CreateDatabase();
            Console.WriteLine(result);
        }
    }
}
