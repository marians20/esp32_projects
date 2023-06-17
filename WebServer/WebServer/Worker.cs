using System.Diagnostics;
using nanoFramework.Hosting;
using WebServer.Lib;

namespace WebServer
{
    internal sealed class Worker : BackgroundService
    {
        private readonly WiFi wifi;
        private readonly WebApi webApi;

        public Worker(WiFi wifi, WebApi webApi)
        {
            this.wifi = wifi;
            this.webApi = webApi;
            this.wifi.Connect();
        }

        protected override void ExecuteAsync()
        {
            Debug.WriteLine($"Ip Address is {wifi.IpAddress}");
            webApi.Start();
        }
    }
}
