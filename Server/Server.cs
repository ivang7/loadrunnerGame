using System.Net.Sockets;
using System.Net;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Server.GameObjects;
using WebSocketSharp;
using WebSocketSharp.Server;

class ServerInstance
{
    private static Map _test;

    public static void Main()
    {

        _test = new Map(30);
        _test.ReadMapFromFile(@"C:\Users\igubanov\Source\LR\Server\resources\map.txt");

        Console.WriteLine(_test.ConvertMapToString());

        var server = new WebSocketServer("ws://localhost:10080");
        server.AddWebSocketService<WebSocketConnections>("/");
        server.Start();
        
        Console.WriteLine("Server has started.{0}Waiting for a connection...", Environment.NewLine);


        Console.ReadKey(true);
        server.Stop();
    }


    private class WebSocketConnections : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"get message {e.Data} from host: {this.Context.Host} with key {this.Context.SecWebSocketKey}");      

            Send(_test.ConvertMapToString());
        }

        protected override void OnOpen()
        {
            Console.WriteLine($"new connection from {this.Context.Host} with key {this.Context.SecWebSocketKey}");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine($"Connect lost {this.Context.Host} with key {this.Context.SecWebSocketKey} reason - {e.Reason}");
        }
    }

    public static string CheckCommand(string command)
    {
        return "";
    }
}