using System.Diagnostics;

namespace AdventOfCode2022.Day13
{
    internal class List : Value
    {
        private readonly List<Value> _values;

        public List(List<Value> values)
        {
            _values = values;
        }

        public List(Value singleValue)
        {
            _values = new List<Value> { singleValue };
        }

        public override ComparisonResult IsSmallerThan(Value other)
        {
            if (other is List otherList)
            {
                int length = int.Min(_values.Count, otherList._values.Count);

                for (int i = 0; i < length; i++)
                {
                    var result = _values[i].IsSmallerThan(otherList._values[i]);
                    if (result != ComparisonResult.Inconclusive)
                    {
                        return result;
                    }
                }

                return (ComparisonResult)int.Sign(_values.Count - otherList._values.Count);
            }
            else if (other is Integer otherInteger)
            {
                return IsSmallerThan(new List(otherInteger));
            }

            throw new UnreachableException();
        }

        public override string ToString() => $"[{string.Join(",", _values)}]";
    }
}
