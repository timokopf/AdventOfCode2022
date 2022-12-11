namespace AdventOfCode2022.Day9
{
    internal readonly struct Direction
    {
        public readonly int X;
        public readonly int Y;

        public static readonly Direction Down = new Direction(0, -1);
        public static readonly Direction Up = new Direction(0, 1);
        public static readonly Direction Right = new Direction(1, 0);
        public static readonly Direction Left = new Direction(-1, 0);

        public Direction(int x, int y)
        {
            X = x; Y = y;
        }
    }
}
