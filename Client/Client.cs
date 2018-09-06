
using System;

using WebSocketSharp;

namespace Example
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Run");

            var ws = new WebSocket("ws://localhost:10080");

            ws.OnMessage += (sender, e) => Console.WriteLine("Laputa says: " + e.Data);

            ws.Connect();
            ws.Send("GET TEST");
            Console.ReadKey(true);

        }
    }
}

