namespace Client.Helper
{
    public static class GameActions
    {
        public static string Up => "UP";
        public static string Down => "DOWN";
        public static string Left => "LEFT";
        public static string Right => "RIGHT";
        public static string Drill => "ACT";
        public static string DrillLeft => "(ACT,LEFT)";
        public static string DrillRight => "(ACT,RIGHT)";
        public static string KillHimself => "ACT(0)";
    }
}