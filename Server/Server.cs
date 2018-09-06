using System.Net.Sockets;
using System.Net;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class Server
{
    public static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 10080);

        server.Start();
        Console.WriteLine("Server has started on 127.0.0.1:80.{0}Waiting for a connection...", Environment.NewLine);

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            MakeNewConnection(client);
        }
    }


    public static void MakeNewConnection(TcpClient client)
    {
        var thread = new Thread(NewClient);
        thread.Start(client);
    }

    public static void NewClient(object data)
    {
        var client = (TcpClient)data;

        string adress = client.Client.AddressFamily.ToString();

        Console.WriteLine("{0} has connected!", adress);

        NetworkStream stream = client.GetStream();

        string command = "";

        while (true)
        {
            if (!stream.DataAvailable)
            {
                if (!client.Connected)
                {
                    Console.WriteLine("{0} diconnected!", adress);
                    break;
                }
                continue;
            }

            byte[] receivedbuffer = new byte[client.Available];

            int receivedbytes = stream.Read(receivedbuffer, 0, receivedbuffer.Length);
            string message = Encoding.UTF8.GetString(receivedbuffer);


            command += message;
            if (message.Substring(message.Length - 2, 2) != "\r\n")
            {
                string answer = CheckCommand(command);



                command = "";
            }
        }
    }

    public static string CheckCommand(string command)
    {
        return "";
    }
}