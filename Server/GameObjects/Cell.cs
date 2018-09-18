using System;

namespace Server.GameObjects
{
    public class Cell
    {
        public int CoordX;
        public int CoordY;
        public CellChar type;

        public Cell(int x, int y, CellChar typeOfCell = CellChar.None)
        {
            CoordX = x;
            CoordY = y;
            type = typeOfCell;
        }
    }

    public abstract class Gamers : Cell
    {
        public Gamers(int x, int y)
            : base(x, y)
        {

        }

        public Cell GetUpCell(Map map)
        {
            if (this.CoordY == 0)
                return null;
            return null;
            //map.

        }

        public bool CheckDrillDeath(Map map)
        {
            
            return true;
        }
    }

    public static class ExtensionsForCell
    {
        public static bool CanBeDrill(this CellChar cell)
        {
            switch (cell)
            {
                case CellChar.Brick:
                    return true;

                default: return false;
            }
        }

        public static bool CanBeMovable(this CellChar cell)
        {
            switch (cell)
            {
                case CellChar.PitFill1:
                case CellChar.PitFill2:
                case CellChar.PitFill3:
                case CellChar.PitFill4:
                case CellChar.None:
                case CellChar.Gold:
                case CellChar.Ladder:
                case CellChar.Pipe:
                    return true;

                default: return false;
            }
        }

        public static bool CanBeFall(this CellChar cell)
        {
            if (cell == CellChar.Ladder)
                return false;

            return CanBeMovable(cell);
        }
    }
}