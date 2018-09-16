using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Server.GameObjects
{
    public class World
    {
        private readonly List<Actor> actors;
        private readonly List<Player> players;
        private readonly List<Hunter> hunters;
        private readonly List<Cell> pits;

        private const int numOfGold = 10;
        private const int numOfHunter = 3;

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

        public string GetMapStringForPlayer(Player player, int notFinish = 0)
        {
            //TODO replace player symbol
            return map.ConvertMapToString();
        }

        public Cell GetFreeCellForNewObject(int notFinish = 0)
        {
            return new Cell(0, 0);
        }

        public void AddNewPlayer(ServerInstance.WebSocketConnections webSocketForPlayer)
        {
            var cell = GetFreeCellForNewObject();
            cell.type = CellChar.HeroLeft;

            var player = new Player(cell.CoordX, cell.CoordY, webSocketForPlayer);
            players.Add(player);

            this.map.Cells[cell.CoordX, cell.CoordY] = cell.type;
        }

        public void RemovePlayer(ServerInstance.WebSocketConnections webSocketForPlayer)
        {
            var player = players.Single(pl => pl.wsSess == webSocketForPlayer);

            players.Remove(player);

            this.map.Cells[player.CoordX, player.CoordY] = CellChar.None;
        }

        public void SendMapForAllPlayer()
        {
            foreach (var player in players)
            {
                player.SendMap(GetMapStringForPlayer(player));
            }
        }

        public void UpdateWorld(int notFinish = 0)
        {
            //FIRST ! check life cycle each pit
            foreach (var pit in pits)
            {
            }

            //SECOND ! apply player command
            foreach (var player in players)
            {
            }

            //THIRD ! move hunters
            foreach (var hunter in hunters)
            {
            }

            SendMapForAllPlayer();
        }
    }
}