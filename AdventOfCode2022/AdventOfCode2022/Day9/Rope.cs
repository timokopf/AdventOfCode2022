namespace AdventOfCode2022.Day9
{
    internal struct Rope
    {
        private Position[] _knots;

        public Position Tail => _knots[^1];

        public Rope() : this(2)
        {
        }
        public Rope(int knotCount)
        {
            _knots= new Position[knotCount];
            Array.Fill(_knots, new Position(0, 0));
        }

        public void Move(Direction direction)
        {
            _knots[0] = _knots[0] + direction;
            for (int i = 1; i < _knots.Length && !Position.AreTouching(_knots[i - 1], _knots[i]); i++)
            {
                direction = _knots[i - 1] - _knots[i];
                _knots[i] += new Direction(Math.Sign(direction.X), Math.Sign(direction.Y));
            }
        }
    }
}
