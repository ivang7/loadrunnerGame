using System;
using System.Threading;
using Client.Helper;
using Server.GameObjects;
using WebSocketSharp;

namespace Client
{
    public class ClientInstance
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Run client");

            var ws = new WebSocket("ws://localhost:10080");
            ws.OnMessage += ReadData;

            ws.Connect();

            ws.Send(GameActions.Up);
            Thread.Sleep(5000);

            while (ws.ReadyState != WebSocketState.Closed)
            {
            }

            Console.WriteLine("Game over, connection closed.");
            Console.ReadKey(true);
        }
        
        public static void ReadData(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Maps:\r\n" + e.Data);

            var m = new Map((int)Math.Sqrt(e.Data.Length));


            Console.WriteLine("\r\nSend action UP\r\n");

            ((WebSocket) sender).Send(GameActions.Up);
            Thread.Sleep(5000);
        }
    }
}

