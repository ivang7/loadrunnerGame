namespace Server.GameObjects
{
    public class NotMovebleCell : Cell
    {
        public NotMovebleCell(int x, int y) : base(x, y)
        {
        }
    }

    public class MovebleCell : Cell
    {
        public MovebleCell(int x, int y) : base(x, y)
        {
        }

        public void MoveTo(int x, int y)
        {

        }
    }

    public class NototClaS
    {
        private Cell[] arr;

        public NototClaS()
        {
            arr = new Cell[10];
            arr[0] = new MovebleCell(1, 1);
            arr[1] = new NotMovebleCell(1, 2);

            var x = arr[0];
            
        }

    }
}