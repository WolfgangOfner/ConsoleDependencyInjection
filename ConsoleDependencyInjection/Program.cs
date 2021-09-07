using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleDependencyInjection
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            Console.WriteLine(GreetWithDependencyInjection(host.Services));

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IGreeter, ConsoleGreeter>()
                        .AddTransient<IFooService, FooService>());
        }

        public static string GreetWithDependencyInjection(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var greeter = provider.GetRequiredService<IGreeter>();

            return greeter.Greet();
        }
    }
}