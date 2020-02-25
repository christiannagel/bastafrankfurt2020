using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace NullableSampleApp
{
    class Program
    {
        static async Task Main()
        {
            using var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<Runner>();
                    services.AddDbContext<BooksContext>(options =>
                    {
                        var connectionString = context.Configuration.GetConnectionString("BastaBooks");
                        options.UseSqlServer(connectionString);
                    });
                })
                .Build();
            var runner = host.Services.GetRequiredService<Runner>();
            await runner.CreateDatabaseAsync();
            runner.ShowBooks();
        }

    }
}
