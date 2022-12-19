using System.Diagnostics;

namespace AdventOfCode2022.Day15
{
    [DebuggerDisplay("{X}, {Y}")]
    public struct Point : IEquatable<Point>
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static int ManhattenDistance(Point p1, Point p2) => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        public bool Equals(Point other) => X == other.X && Y == other.Y;
        public override bool Equals(object? obj) => obj is Point other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
