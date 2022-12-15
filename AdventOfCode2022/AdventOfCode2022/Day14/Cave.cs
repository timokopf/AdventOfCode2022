namespace AdventOfCode2022.Day14
{
    internal class Cave
    {
        private readonly Element[,] _elements;
        private readonly AABB _boundingBox;

        private Cave(Element[,] elements, AABB boundingBox)
        {
            _elements = elements;
            _boundingBox = boundingBox;
        }

        public static Cave CreateForPart1(IEnumerable<RockPath> rockPaths, Point sandOrigin)
        {
            AABB boundingBox = rockPaths.Aggregate(new AABB(sandOrigin, sandOrigin), (aabb, rockPath) => aabb.MergeWith(rockPath.GetBoundingBox()));
            IEnumerable<Point> rocks = rockPaths.SelectMany(rp => rp.GetPoints());

            Element[,] elements = new Element[boundingBox.BottomRight.X - boundingBox.TopLeft.X + 1, boundingBox.BottomRight.Y - boundingBox.TopLeft.Y + 1];

            foreach (var rock in rocks)
            {
                elements[rock.X - boundingBox.TopLeft.X, rock.Y - boundingBox.TopLeft.Y] = Element.Rock;
            }

            return new Cave(elements, boundingBox);
        }

        public static Cave CreateForPart2(IEnumerable<RockPath> rockPaths, Point sandOrigin)
        {
            AABB boundingBox = rockPaths.Aggregate(new AABB(sandOrigin, sandOrigin), (aabb, rockPath) => aabb.MergeWith(rockPath.GetBoundingBox()));
            int caveHeight = boundingBox.BottomRight.Y + 1;

            RockPath floor = new RockPath(new[] { new Point(sandOrigin.X - caveHeight * 2, caveHeight + 1), new Point(sandOrigin.X + caveHeight * 2, caveHeight + 1) });

            boundingBox = boundingBox.MergeWith(floor.GetBoundingBox());
            IEnumerable<Point> rocks = rockPaths.Concat(new[] { floor }).SelectMany(rp => rp.GetPoints());

            Element[,] elements = new Element[boundingBox.BottomRight.X - boundingBox.TopLeft.X + 1, boundingBox.BottomRight.Y - boundingBox.TopLeft.Y + 1];

            foreach (var rock in rocks)
            {
                elements[rock.X - boundingBox.TopLeft.X, rock.Y - boundingBox.TopLeft.Y] = Element.Rock;
            }

            return new Cave(elements, boundingBox);
        }

        public bool PourSand(Point from)
        {
            if (IsAirAt(from) is false)
            {
                return false;
            }
            Point below = from + Direction.Down;

            if (IsInsideCave(below) is false)
            {
                return false;
            }

            if (IsAirAt(below))
            {
                return PourSand(below);
            }

            Point belowLeft = below + Direction.Left;
            if (IsAirAt(belowLeft))
            {
                return PourSand(belowLeft);
            }

            Point belowRight = below + Direction.Right;
            if (IsAirAt(belowRight))
            {
                return PourSand(belowRight);
            }

            PlaceElement(Element.Sand, from);

            return true;
        }

        private bool IsAirAt(Point point)
        {
            if (_boundingBox.Contains(point) is false)
            {
                return true;
            }

            var x = point.X - _boundingBox.TopLeft.X;
            var y = point.Y - _boundingBox.TopLeft.Y;

            return _elements[x, y] == Element.Air;
        }
        private bool IsInsideCave(Point point) => _boundingBox.Contains(point);

        private void PlaceElement(Element element, Point point)
        {
            Point translated = new Point(point.X - _boundingBox.TopLeft.X, point.Y - _boundingBox.TopLeft.Y);

            _elements[translated.X, translated.Y] = element;
        }
    }
}
