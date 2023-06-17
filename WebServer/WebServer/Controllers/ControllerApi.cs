using nanoFramework.WebServer;
using System.Device.Gpio;
using System.Diagnostics;
using System.Net;

namespace WebServer.Controllers
{
    public sealed class ControllerApi
    {
        const int PinLed = 2;

        private readonly GpioController controller;

        public ControllerApi(GpioController controller)
        {
            this.controller = controller;
            this.controller.OpenPin(PinLed, PinMode.Output);
        }

        /// <summary>
        /// Switch on or off the led
        /// </summary>
        /// <param name="e">Web server context</param>
        [Route("led")]
        public void Led(WebServerEventArgs e)
        {
            Debug.WriteLine(e.Context.Request.RawUrl);
            var paramsQuery = nanoFramework.WebServer.WebServer.DecodeParam(e.Context.Request.RawUrl);
            if (paramsQuery is not { Length: > 0 })
            {
                nanoFramework.WebServer.WebServer.OutputHttpCode(e.Context.Response, HttpStatusCode.OK);
                return;
            }

            if (paramsQuery[0].Name == "l")
            {
                controller.Write(
                    PinLed,
                    paramsQuery[0].Value == "on" ? PinValue.High : PinValue.Low);
            }

            nanoFramework.WebServer.WebServer.OutputHttpCode(e.Context.Response, HttpStatusCode.OK);
        }

        [Route("")]
        public void Test(WebServerEventArgs e)
        {
            Debug.WriteLine(e.Context.Request.RawUrl);
            nanoFramework.WebServer.WebServer.OutputHttpCode(e.Context.Response, HttpStatusCode.OK);
        }
    }
}
