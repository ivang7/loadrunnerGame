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

        while (true)
        {
            byte[] receivedbuffer = new byte[client.Available];




            int receivedbytes = stream.Read(receivedbuffer, 0, receivedbuffer.Length);
            string message = Encoding.UTF8.GetString(receivedbuffer);
  

            //byte[] sendBuffer = Encoding.UTF8.GetBytes(newmessage);
            //stream.Write(sendBuffer, 0, sendBuffer.Length);

            if(new System.Text.RegularExpressions.Regex("^GET").IsMatch(message))
            {
                const string eol = "\r\n"; // HTTP/1.1 defines the sequence CR LF as the end-of-line marker

                Byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + eol
                                                                                            + "Connection: Upgrade" + eol
                                                                                            + "Upgrade: websocket" + eol
                                                                                            + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
                                                                                                System.Security.Cryptography.SHA1.Create().ComputeHash(
                                                                                                    Encoding.UTF8.GetBytes(
                                                                                                        new System.Text.RegularExpressions.Regex("Sec-WebSocket-Key: (.*)").Match(message).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                                                                                                    )
                                                                                                )
                                                                                            ) + eol
                                                                                            + eol);

                stream.Write(response, 0, response.Length);
            }
        }
    }
}