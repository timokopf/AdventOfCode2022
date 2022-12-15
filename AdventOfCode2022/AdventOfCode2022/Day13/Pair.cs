namespace AdventOfCode2022.Day13
{
    internal class Pair
    {
        private Packet _left;
        private Packet _right;

        public Pair(Packet left, Packet right)
        {
            _left = left;
            _right = right;
        }

        public bool IsInRightOrder()
        {
            return _left.IsSmallerThan(_right) == ComparisonResult.InRightOrder;
        }
    }
}
