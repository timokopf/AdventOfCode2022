namespace AdventOfCode2022.Day12
{
    public class Solution
    {
        private (int x, int y) _end;
        private char[,] _heightMap;
        private int[,] _distancesToEnd;
        private (int x, int y) _start;

        public int SolvePart1(string[] input)
        {
            _heightMap = ParseHeightMap(input, out _start, out _end);
            _distancesToEnd = new int[_heightMap.GetLength(0), _heightMap.GetLength(1)];
            for (int x = 0; x < _distancesToEnd.GetLength(0); x++)
            {
                for (int y = 0; y < _distancesToEnd.GetLength(1); y++)
                {
                    _distancesToEnd[x, y] = int.MaxValue;
                }
            }

            FindShortestPath(_end, 0);

            return _distancesToEnd[_start.x, _start.y];
        }

        public int SolvePart2(string[] input)
        {
            _ = SolvePart1(input);

            int minDistanceToEnd = int.MaxValue;

            for (int x = 0; x < _heightMap.GetLength(0); x++)
            {
                for (int y = 0; y < _heightMap.GetLength(1); y++)
                {
                    if (_heightMap[x, y] == 'a')
                    {
                        minDistanceToEnd = int.Min(minDistanceToEnd, _distancesToEnd[x, y]);
                    }
                }
            }

            return minDistanceToEnd;
        }

        private void FindShortestPath((int x, int y) position, int distanceTravelled)
        {
            if (_distancesToEnd[position.x, position.y] <= distanceTravelled)
            {
                return;
            }

            _distancesToEnd[position.x, position.y] = distanceTravelled;

            if (position == _start)
            {
                return;
            }

            var neighbors = FindNeighbors(position);
            foreach (var neighbor in neighbors)
            {
                int heightDiff = _heightMap[position.x, position.y] - _heightMap[neighbor.x, neighbor.y];
                if (heightDiff > 1)
                {
                    continue;
                }

                FindShortestPath(neighbor, distanceTravelled + 1);
            }
        }

        private IEnumerable<(int x, int y)> FindNeighbors((int x, int y) pos)
        {
            if (pos.x > 0)
            {
                yield return (pos.x - 1, pos.y);
            }
            if (pos.y > 0)
            {
                yield return (pos.x, pos.y - 1);
            }
            if (pos.x < _heightMap.GetLength(0) - 1)
            {
                yield return (pos.x + 1, pos.y);
            }
            if (pos.y < _heightMap.GetLength(1) - 1)
            {
                yield return (pos.x, pos.y + 1);
            }
        }

        private static char[,] ParseHeightMap(string[] input, out (int x, int y) start, out (int x, int y) end)
        {
            start = end = default;

            int height = input.Length;
            int width = input[0].Length;

            char[,] heightMap = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (input[y][x] == 'S')
                    {
                        start = (x, y);
                        heightMap[x, y] = 'a';
                    } else if (input[y][x] == 'E')
                    {
                        end = (x, y);
                        heightMap[x, y] = 'z';
                    }
                    else
                    {
                        heightMap[x, y] = input[y][x];
                    }
                }
            }

            return heightMap;
        }
    }
}
