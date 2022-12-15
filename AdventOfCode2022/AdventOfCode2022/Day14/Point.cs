namespace AdventOfCode2022.Day14
{
    internal struct Point : IEquatable<Point>
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj) => obj is Point other && Equals(other);
        public bool Equals(Point other) => X == other.X && Y == other.Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point a, Point b) => a.Equals(b);
        public static bool operator !=(Point a, Point b) => !(a == b);

    }
}
