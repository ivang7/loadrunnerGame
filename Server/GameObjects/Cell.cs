using System;

namespace Server.GameObjects
{
    public class Cell
    {
        protected int CoordX;
        protected int CoordY;
        protected CellChar type;

        public Cell(int x, int y, CellChar typeOfCell = CellChar.None)
        {
            CoordX = x;
            CoordY = y;
            type = typeOfCell;
        }
    }

    public abstract class Actor : Cell
    {
        private World world;

        public Actor(int x, int y, World world)
            : base(x, y)
        {
            this.world = world;
        }

        public Cell GetUpCell()
        {
            return this.world.GetCell(this.CoordX, this.CoordY - 1);
        }

        public Cell GetDownCell()
        {
            return this.world.GetCell(this.CoordX, this.CoordY + 1);
        }

        public Cell GetLeftCell()
        {
            return this.world.GetCell(this.CoordX - 1, this.CoordY);
        }

        public Cell GetRightCell()
        {
            return this.world.GetCell(this.CoordX + 1, this.CoordY);
        }

        public bool CheckDeathInPit(Map map)
        {
            return true;
        }
    }

    public class Player : Actor
    {
        private string uid;

        public Player(int x, int y, World world)
            : base(0, 0, world)
        {
        }
    }

    public class Hunter : Actor
    {
        public Hunter(int x, int y, World world)
            : base(x, y, world)
        {
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