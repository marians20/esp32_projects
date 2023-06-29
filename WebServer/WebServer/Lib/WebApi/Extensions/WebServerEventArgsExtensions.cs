using nanoFramework.Json;
using nanoFramework.WebServer;
using WS = nanoFramework.WebServer;
using System.Net;

namespace WebServer.Lib.Extensions
{
    public static class WebServerEventArgsExtensions
    {
        public static void Ok(this WebServerEventArgs e, object data)
        {
            var content = JsonConvert.SerializeObject(data);
            e.Context.Response.ContentType = "application/json";
            WS.WebServer.OutPutStream(e.Context.Response, content);
        }
    }
}
