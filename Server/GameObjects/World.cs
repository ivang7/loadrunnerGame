using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server.GameObjects
{
    public class World
    {
        private readonly List<Actor> actors;
        private readonly List<Player> players;
        private readonly List<Hunter> hunters;

        private Map map;

        public int Size => map.SizeOfMap;

        public World(Map mapOfWorld)
        {
            this.map = mapOfWorld;
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || y < 0 || x > Size - 1 || y > Size - 1)
                return null;

            return new Cell(x, y, map.Cells[x, y]);
        }








    }
}