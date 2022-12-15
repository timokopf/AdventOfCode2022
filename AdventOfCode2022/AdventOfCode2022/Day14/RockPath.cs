namespace AdventOfCode2022.Day14
{
    internal class RockPath
    {
        private readonly IReadOnlyList<Point> _junctions;

        public RockPath(IEnumerable<Point> junctions)
        {
            _junctions = junctions.ToArray();
        }

        public AABB GetBoundingBox()
        {
            var topLeft = new Point(_junctions.Select(p => p.X).Min(), _junctions.Select(p => p.Y).Min());
            var bottomRight = new Point(_junctions.Select(p => p.X).Max(), _junctions.Select(p => p.Y).Max());

            return new AABB(topLeft, bottomRight);
        }

        public IEnumerable<Point> GetPoints()
        {
            IEnumerable<(Point First, Point Second)> segments = _junctions.Zip(_junctions.Skip(1));
            foreach (var segment in segments)
            {
                Direction step = Direction.BetweenPoints(segment.First, segment.Second);
                for (Point cursor = segment.First; cursor != segment.Second; cursor += step)
                {
                    yield return cursor;
                }
            }

            yield return segments.Last().Second;
        }
    }
}
