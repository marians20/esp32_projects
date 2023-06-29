using System;

namespace WebServer.Dtos
{
    public class NamedMessage
    {
        public NamedMessage(string name, string message)
        {
            this.name = name;
            this.message = message;
            utcTimeStamp = DateTime.UtcNow;
        }

        public string name { get; }

        public string message { get; }

        public DateTime utcTimeStamp { get; }
    }
}
