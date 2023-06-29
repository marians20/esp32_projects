using System.Diagnostics;
using WebServer.Dtos;
using WebServer.Lib.Extensions;
using WS=nanoFramework.WebServer;

namespace WebServer.Controllers
{
    public sealed class ControllerApi
    {
        [WS.Route("/")]
        [WS.Method("GET")]
        public void Test(WS.WebServerEventArgs e)
        {
            Debug.WriteLine(e.Context.Request.RawUrl);
            e.Ok(new NamedMessage("Marian", "Hello"));
        }
    }
}
