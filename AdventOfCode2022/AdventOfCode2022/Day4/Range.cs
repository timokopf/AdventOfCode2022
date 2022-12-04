namespace AdventOfCode2022.Day4
{
    internal class Range
    {
        private readonly int _start;
        private readonly int _end;

        public Range(int start, int end)
        {
            _start = start;
            _end = end;
        }

        public bool Contains(Range other) => _start <= other._start && _end >= other._end;

        public bool OverlapsWith(Range other)
        {
            var range = this;
            if (range._start > other._start)
            {
                (range, other) = (other, range);
            }

            if (range._end < other._start)
            {
                return false;
            }

            return true;
        }
    }
}
