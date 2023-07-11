using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;
using nanoFramework.Hosting;
using WebServer.Lib;

namespace WebServer
{
    internal sealed class Worker : BackgroundService
    {
        private readonly WiFi wifi;
        private readonly WebApi webApi;
        private readonly GpioController gpioController;
        private readonly GpioPin led;

        public Worker(WiFi wifi, WebApi webApi)
        {
            gpioController = new GpioController();
            led = gpioController.OpenPin(2, PinMode.Output);
            this.wifi = wifi;
            this.webApi = webApi;
            //this.wifi.Connect();
            this.wifi.ScanNetworks();
        }

        protected override void ExecuteAsync()
        {
            var thd = new Thread(() =>
            {
                var oldTime = DateTime.UtcNow;
                while (true)
                {
                    Thread.Sleep(500);
                    led.Toggle();
                    var time = DateTime.UtcNow;
                    if (time.Second != oldTime.Second)
                    {
                        oldTime = time;
                        Debug.WriteLine($"{time:G}");
                    }
                    
                }
            });

            thd.Start();
            webApi.Start();
        }
    }
}
