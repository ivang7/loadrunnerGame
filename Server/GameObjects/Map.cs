using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Server.GameObjects
{
    public class Map
    {
        private readonly CellChar[,] Cells = null;

        public int SizeOfMap { get; }

        public Map(int size = 30)
        {
            this.SizeOfMap = size;
            this.Cells = new CellChar[SizeOfMap, SizeOfMap];
        }

        public void ReadMapFromFile(string fileName)
        {
            var data = File.ReadAllText(fileName);

            Console.WriteLine(data);

            data = data.Replace("\r", "");
            data = data.Replace("\n", "");
            
            ConvertMapFromString(data);
        }

        public void ConvertMapFromString(string data)
        {
            var fileSize = data.Length;

            if (fileSize != SizeOfMap * SizeOfMap)
            {
                throw new System.Exception($"Map size {SizeOfMap * SizeOfMap} not equal file size {fileSize}");
            }

            for (int row = 0; row < SizeOfMap; row++)
            {
                for (int column = 0; column < SizeOfMap; column++)
                {
                    var currentCharCounter = row * SizeOfMap + column;

                    Cells[row, column] = (CellChar)(int)data[currentCharCounter];
                    if (!((IList)Enum.GetValues(typeof(CellChar))).Contains(Cells[row, column]))
                    {
                        Console.WriteLine($"Error: Map have unknown cell = {data[currentCharCounter]} on row:{row + 1} column:{column + 1}");
                    }
                }
            }
        }


        public string ConvertMapToString()
        {
            string map = "";

            for (int row = 0; row < SizeOfMap; row++)
            {
                for (int column = 0; column < SizeOfMap; column++)
                {
                    var currentCell = (int) Cells[row, column];
                    map += (char)(currentCell);
                }
            }

            return map;
        }
    }
}