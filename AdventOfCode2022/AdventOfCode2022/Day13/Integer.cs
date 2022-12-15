using System.Diagnostics;

namespace AdventOfCode2022.Day13
{
    internal class Integer : Value
    {
        private int _value;

        public Integer(int value)
        {
            _value = value;
        }

        public override ComparisonResult IsSmallerThan(Value other)
        {
            if (other is Integer otherInteger)
            {
                return (ComparisonResult)_value.CompareTo(otherInteger._value);
            }
            else if (other is List otherList)
            {
                return new List(this).IsSmallerThan(otherList);
            }

            throw new UnreachableException();
        }
        public override string ToString() => _value.ToString();
    }
}
