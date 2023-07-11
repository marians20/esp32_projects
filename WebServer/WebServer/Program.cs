using System;
using System.Diagnostics;
using WebServer.Controllers;

namespace WebServer
{
    public class Program
    {
        private static readonly Type[] Controllers = new Type[] {
            typeof(ControllerApi), typeof(ControllerWebpages)
        };
        public static void Main()
        {
            //IHost host = CreateHostBuilder().Build();
            //host.Run();
            Debug.WriteLine("Ai scapat Sapunul!");
        }

        //public static IHostBuilder CreateHostBuilder() =>
        //    Host.CreateDefaultBuilder()
        //        .ConfigureServices(services =>
        //        {
        //            services.TryAdd(
        //                new ServiceDescriptor(
        //                    typeof(WiFiConfig),
        //                    new WiFiConfig("GoAway", "D@n1elSiAnca")));
        //            services.TryAdd(
        //                new ServiceDescriptor(
        //                    typeof(WebApiConfig),
        //                    new WebApiConfig(
        //                        80,
        //                        false,
        //                        Controllers)));
        //            services.TryAdd(
        //                new ServiceDescriptor(
        //                    typeof(StorageFolder),
        //                    KnownFolders.RemovableDevices.GetFolders()[0]));

        //            services.AddSingleton(typeof(WiFi));
        //            services.AddSingleton(typeof(GpioController));
        //            services.AddSingleton(typeof(WebApi));
        //            services.AddHostedService(typeof(Worker));
        //        });
    }
}
