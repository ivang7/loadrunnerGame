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

    public class Pit : Cell
    {

        private const int stepForLife = 5;
        private int currentStep;

        public new CellChar type
        {
            get
            {
                CellChar currentBlock = CellChar.Brick;

                if (this.currentStep == stepForLife)
                    currentBlock = CellChar.DrillPit;
                else if (this.currentStep > 0 && this.currentStep < stepForLife)
                    Enum.TryParse<CellChar>($"PitFill{this.currentStep}", out currentBlock);

                return currentBlock;
            }
        }

        public Pit(int x, int y)
            : base(x, y)
        {
            currentStep = stepForLife;
        }

        public Pit NextStep()
        {
            this.currentStep++;
            return this;
        }
    }

    public abstract class Actor : Cell
    {
        //private World world;

        public Actor(int x, int y)
            : base(x, y)
        {
            //this.world = world;
        }

        //public Cell GetUpCell()
        //{
        //    return this.world.GetCell(this.CoordX, this.CoordY - 1);
        //}

        //public Cell GetDownCell()
        //{
        //    return this.world.GetCell(this.CoordX, this.CoordY + 1);
        //}

        //public Cell GetLeftCell()
        //{
        //    return this.world.GetCell(this.CoordX - 1, this.CoordY);
        //}

        //public Cell GetRightCell()
        //{
        //    return this.world.GetCell(this.CoordX + 1, this.CoordY);
        //}

        public bool CheckDeathInPit(Map map)
        {
            return true;
        }
    }

    public class Player : Actor
    {
        public readonly ServerInstance.WebSocketConnections wsSess;

        public Player(int x, int y, ServerInstance.WebSocketConnections webSocketSession)
            : base(0, 0)
        {
            this.wsSess = webSocketSession;
        }

        public void SendMap(string map)
        {
            wsSess.Send(map);
        }
    }

    public class Hunter : Actor
    {
        public Hunter(int x, int y)
            : base(x, y)
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

        public static bool CanBeFall(CellChar cellDown)
        {
            if (cellDown == CellChar.Ladder)
                return false;

            return CanBeMovable(cellDown);
        }
    }
}