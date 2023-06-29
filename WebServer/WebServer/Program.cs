using System;
using System.Device.Gpio;
using Windows.Storage;
using nanoFramework.Hosting;
using nanoFramework.DependencyInjection;
using WebServer.Controllers;
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
                    services.TryAdd(
                        new ServiceDescriptor(
                            typeof(WebApiConfig),
                            new WebApiConfig(
                                80,
                                false,
                                new Type[]{typeof(ControllerApi)})));
                    services.TryAdd(
                        new ServiceDescriptor(
                            typeof(StorageFolder),
                            KnownFolders.RemovableDevices.GetFolders()[0]));

                    services.AddSingleton(typeof(WiFi));
                    services.AddSingleton(typeof(GpioController));
                    services.AddSingleton(typeof(WebApi));
                    services.AddHostedService(typeof(Worker));
                });
    }
}
