namespace AdventOfCode2022.Day13
{
    internal abstract class Value
    {
        public abstract ComparisonResult IsSmallerThan(Value other);
    }
}
