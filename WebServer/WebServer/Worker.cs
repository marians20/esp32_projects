using System.Diagnostics;
using nanoFramework.Hosting;
using WebServer.Lib;

namespace WebServer
{
    internal sealed class Worker : BackgroundService
    {
        private readonly WiFi wifi;

        public Worker(WiFi wifi)
        {
            this.wifi = wifi;
            this.wifi.Connect();
        }

        protected override void ExecuteAsync()
        {
            Debug.WriteLine($"Ip Address is {wifi.IpAddress}");
        }
    }
}
