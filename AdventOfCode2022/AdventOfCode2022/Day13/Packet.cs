namespace AdventOfCode2022.Day13
{
    internal class Packet : IComparable<Packet>
    {
        public List Values { get; set; }

        public int CompareTo(Packet? other) => (int)IsSmallerThan(other!);

        public ComparisonResult IsSmallerThan(Packet other)
        {
            return Values.IsSmallerThan(other.Values);
        }
    }
}
