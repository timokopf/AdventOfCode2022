namespace AdventOfCode2022.Day14
{
    internal struct Direction
    {
        public readonly int DX;
        public readonly int DY;

        public static Direction Down = new Direction(0, 1);
        public static Direction Left = new Direction(-1, 0);
        public static Direction Right = new Direction(1, 0);

        private Direction(int dx, int dy)
        {
            DX = dx;
            DY = dy;
        }

        public static Direction BetweenPoints(Point from, Point to)
        {
            return new Direction(int.Sign(to.X - from.X), int.Sign(to.Y - from.Y));
        }

        public static Point operator +(Point p, Direction d)
        {
            return new Point(p.X + d.DX, p.Y + d.DY);
        }
    }
}
