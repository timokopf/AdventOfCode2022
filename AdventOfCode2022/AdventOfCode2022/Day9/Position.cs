using System.Diagnostics;
using System.Numerics;

namespace AdventOfCode2022.Day9
{
    [DebuggerDisplay("{X}, {Y}")]
    internal readonly struct Position : IAdditionOperators<Position, Direction, Position>, IEquatable<Position>, ISubtractionOperators<Position, Position, Direction>
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position location, Direction direction) => new Position(location.X + direction.X, location.Y + direction.Y);

        public static Direction operator -(Position left, Position right) => new Direction(left.X - right.X, left.Y - right.Y);

        public static bool AreTouching(Position left, Position right)
        {
            if (Math.Abs(left.X - right.X) > 1)
            {
                return false;
            }

            if (Math.Abs(left.Y - right.Y) > 1)
            {
                return false;
            }

            return true;
        }

        public bool Equals(Position other) => X == other.X && Y == other.Y;
        public override bool Equals(object obj) => obj is Position position && Equals(position);

        public override int GetHashCode() => HashCode.Combine(X, Y);

    }
}
