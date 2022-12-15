namespace AdventOfCode2022.Day14
{
    internal struct AABB
    {
        private readonly Point _topLeft;
        private readonly Point _bottomRight;

        public Point TopLeft => _topLeft;
        public Point BottomRight => _bottomRight;

        public AABB(Point topLeft, Point bottomRight)
        {
            _topLeft= topLeft;
            _bottomRight= bottomRight;
        }

        public bool Contains(Point point)
        {
            if (point.X < _topLeft.X)
            {
                return false;
            }

            if (point.X > _bottomRight.X)
            {
                return false;
            }

            if (point.Y < _topLeft.Y)
            {
                return false;
            }

            if (point.Y > _bottomRight.Y)
            {
                return false;
            }

            return true;
        }

        public AABB MergeWith(AABB other)
        {
            var topLeft = new Point(int.Min(_topLeft.X, other._topLeft.X), int.Min(_topLeft.Y, other._topLeft.Y));
            var topRight = new Point(int.Max(_bottomRight.X, other._bottomRight.X), int.Max(_bottomRight.Y, other._bottomRight.Y));

            return new AABB(topLeft, topRight);
        }
    }
}
