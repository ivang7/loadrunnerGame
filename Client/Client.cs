using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Client.Helper;
using Server.GameObjects;
using WebSocketSharp;

namespace Client
{
    public class ClientInstance
    {
        static Map oldMap;

        public static void Main(string[] args)
        {
            Console.SetWindowSize(60, 61);
            Console.WriteLine("Run client");

            //var ws = new WebSocket("ws://localhost:10080");
            var ws = new WebSocket("ws://loderunner.luxoft.com:8080/codenjoy-contest/ws?user=igubanov@luxoft.com&code=4450324501444815343");

            ws.OnMessage += ReadData;

            ws.Connect();

            ws.Send(GameActions.Up);

            while (ws.ReadyState != WebSocketState.Closed)
            {
            }

            Console.WriteLine("Game over, connection closed.");
            Console.ReadKey(true);
        }

        public static void ReadData(object sender, MessageEventArgs e)
        {

            var m = new Map((int)Math.Sqrt(e.Data.Length));
            m.ConvertMapFromString(e.Data);
            string newStringMap = m.ConvertMapToString();

            //List<Cell> differentCells = null;
            if (oldMap != null)
            {
                var differentCells = CompareTwoMaps(oldMap, m);

                for (int i = 0; i < newStringMap.Length; i++)
                {
                    var r = i / m.SizeOfMap;
                    var c = i % m.SizeOfMap;

                    if (c == 0)
                        Console.WriteLine("");

                    var cell = differentCells.SingleOrDefault(cl => cl.CoordX == c && cl.CoordY == r);
                    if (cell != null)
                    {
                        var nameOfTypeCell = Enum.GetName(cell.type.GetType(), cell.type);
                        if (nameOfTypeCell.StartsWith("Hero"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }

                        Console.Write(newStringMap[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(newStringMap[i]);
                    }
                }
            }

            int rand = new Random().Next() % 4;
            var command = "";
            switch (rand)
            {
                case 0:
                    command = GameActions.Up;
                    break;
                case 1:
                    command = GameActions.Left;
                    break;
                case 2:
                    command = GameActions.Right;
                    break;
                case 3:
                    command = GameActions.Down;
                    break;
            }


            Console.WriteLine($"\r\nSend action {command}\r\n");
            ((WebSocket)sender).Send(command);

            oldMap = m;
            //Thread.Sleep(5000);
        }

        public static List<Cell> CompareTwoMaps(Map mapOld, Map mapNew)
        {
            var mapOldString = mapOld.ConvertMapToString();
            var mapNewString = mapNew.ConvertMapToString();

            var differentCell = new List<Cell>();

            for (int row = 0; row < mapOld.SizeOfMap; row++)
                for (int column = 0; column < mapOld.SizeOfMap; column++)
                {
                    if (mapOldString[row * mapOld.SizeOfMap + column] != mapNewString[row * mapOld.SizeOfMap + column])
                    {
                        differentCell.Add(new Cell(column, row,
                            (CellChar)mapNewString[row * mapOld.SizeOfMap + column]));
                    }
                }

            return differentCell;
        }


    }
}

