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

        TcpClient client = server.AcceptTcpClient();

        Console.WriteLine("A client connected.");

        NetworkStream stream = client.GetStream();

        //enter to an infinite cycle to be able to handle every change in stream
        while (true)
        {

            while (!stream.DataAvailable) ;

            Byte[] bytes = new Byte[client.Available];

            stream.Read(bytes, 0, bytes.Length);

            String data = Encoding.UTF8.GetString(bytes);


            if (new System.Text.RegularExpressions.Regex("^GET").IsMatch(data))
            {
                const string eol = "\r\n"; // HTTP/1.1 defines the sequence CR LF as the end-of-line marker

                Byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + eol
                                                                                            + "Connection: Upgrade" + eol
                                                                                            + "Upgrade: websocket" + eol
                                                                                            + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
                                                                                                System.Security.Cryptography.SHA1.Create().ComputeHash(
                                                                                                    Encoding.UTF8.GetBytes(
                                                                                                        new System.Text.RegularExpressions.Regex("Sec-WebSocket-Key: (.*)").Match(data).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                                                                                                    )
                                                                                                )
                                                                                            ) + eol
                                                                                            + eol);

                stream.Write(response, 0, response.Length);
            }
        }
    }
}