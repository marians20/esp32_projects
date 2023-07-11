using System;
using System.Diagnostics;
using nanoFramework.WebServer;
using System.Threading;
using Windows.Storage;

namespace WebServer.Lib
{
    public class WebApi
    {
        private readonly WebApiConfig config;

        public WebApi(WebApiConfig config, StorageFolder storage)
        {
            this.config = config;
        }

        public nanoFramework.WebServer.WebServer Server
        {
            get
            {
                var server = new nanoFramework.WebServer.WebServer(
                    config.Port,
                    config.UseTls ? HttpProtocol.Https : HttpProtocol.Http,
                    config.Controllers);

                if (!config.UseTls)
                {
                    return server;
                }

                server.HttpsCert = config.Certificate;
                server.SslProtocols = System.Net.Security.SslProtocols.Tls11 | System.Net.Security.SslProtocols.Tls12;
                return server;
            }
        }

        public void Start()
        {
            try
            {
                using var server = Server;
                server.Start();
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
