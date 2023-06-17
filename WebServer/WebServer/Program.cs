using nanoFramework.Hosting;
using System.Diagnostics;
using System.Threading;
using nanoFramework.DependencyInjection;
using WebServer.Lib;

namespace WebServer
{
    public class Program
    {
        public static void Main()
        {
            IHost host = CreateHostBuilder().Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.TryAdd(
                        new ServiceDescriptor(
                            typeof(WiFiConfig),
                            new WiFiConfig("GoAway", "D@n1elSiAnca")));

                    services.AddSingleton(typeof(WiFi));
                    services.AddHostedService(typeof(Worker));
                });
    }
}
