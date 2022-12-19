using System.Diagnostics;

namespace AdventOfCode2022.Day15
{
    [DebuggerDisplay("{From} - {To}")]
    internal struct Interval : IComparable<Interval>, IEquatable<Interval>
    {
        public int From;
        public int To;

        public Interval(int from, int to)
        {
            From = from; To = to;
        }

        public int CompareTo(Interval other)
        {
            if (Equals(other))
            {
                return 0;
            }

            return From.CompareTo(other.From);
        }

        public IEnumerable<int> Enumerate()
        {
            return Enumerable.Range(From, To - From + 1);
        }

        public bool Equals(Interval other) => To == other.To && From == other.From;
        public override bool Equals(object? obj) => obj is Interval other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(From, To);
    }
}
