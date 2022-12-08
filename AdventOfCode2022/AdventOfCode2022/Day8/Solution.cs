using System.Collections;

namespace AdventOfCode2022.Day8
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            Grid grid = new Grid(ParseInput(input));

            BitArray[] sinksRowWise = Enumerable.Range(0, grid.Height).Select(grid.GetRow).Select(FindSinks).ToArray();
            BitArray[] sinksColWise = Enumerable.Range(0, grid.Width).Select(grid.GetColumn).Select(FindSinks).ToArray();

            int invisibleTreeCount = 0;
            for (int y = 1; y < grid.Height - 1; y++)
            {
                for (int x = 1; x < grid.Width - 1; x++)
                {
                    bool rowWise = sinksRowWise[x][y];
                    bool colWise = sinksColWise[y][x];

                    if (rowWise && colWise)
                    {
                        invisibleTreeCount++;
                    }
                }
            }

            return grid.Width * grid.Height - invisibleTreeCount;
        }

        public int SolvePart2(string[] input)
        {
            Grid grid = new Grid(ParseInput(input));

            int maxScenicScore = 0;

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    int scenicScore = CalculateScenicScore(x, y, grid);
                    maxScenicScore = Math.Max(maxScenicScore, scenicScore);
                }
            }

            return maxScenicScore;
        }

        private int CalculateScenicScore(int x, int y, Grid grid)
        {
            if (x == 0 || y == 0 || x == grid.Width - 1 || y == grid.Height - 1)
            {
                return 0;
            }

            int tree = grid[y, x];

            IReadOnlyList<int> col = grid.GetColumn(x);
            int distTop = 0;
            int iY = y;
            while (--iY >= 0 && col[iY] <= tree)
            {
                distTop++;
                if (col[iY] == tree)
                {
                    break;
                }
            }

            int distBottom = 0;
            iY = y;
            while (++iY < col.Count && col[iY] <= tree)
            {
                distBottom++;
                if (col[iY] == tree)
                {
                    break;
                }
            }

            IReadOnlyList<int> row = grid.GetRow(y);
            int distLeft = 0;
            int iX = x;
            while (--iX >= 0 && row[iX] < tree)
            {
                distLeft++;
                if (row[iX] == tree)
                {
                    break;
                }
            }

            int distRight = 0;
            iX = x;
            while (++iX < row.Count && row[iX] <= tree)
            {
                distRight++;
                if (row[iX] == tree)
                {
                    break;
                }
            }

            return distTop * distBottom * distLeft * distRight;
        }

        private static int[,] ParseInput(string[] input)
        {
            int height = input.Length;
            int width = input[0].Length;

            int[,] result = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result[y, x] = input[y][x] - '0';
                }
            }

            return result;
        }

        public static BitArray FindSinks(IReadOnlyList<int> trees)
        {
            bool hasAtLeastOne = false;
            BitArray result = new BitArray(trees.Count);

            int maxTree = trees[0];
            for (int i = 1; i < trees.Count; i++)
            {
                bool isInSink = trees[i] <= maxTree;
                if (isInSink)
                {
                    result[i] = true;
                }
                else
                {
                    maxTree = trees[i];
                }
            }

            maxTree = trees[^1];
            result[^1] = false;
            for (int i = trees.Count - 2; i >= 0; i--)
            {
                bool isInSink = trees[i] <= maxTree;
                if (isInSink)
                {
                    hasAtLeastOne |= result[i] &= true;
                }
                else
                {
                    result[i] = false;
                    maxTree = trees[i];
                }
            }

            return result;
        }
    }

    public class Grid
    {
        private readonly int[,] _grid;
        private readonly int _height;
        private readonly int _width;

        public int Height => _height;
        public int Width => _width;

        public int this[int y, int x] => _grid[y, x];

        public Grid(int[,] grid)
        {
            _grid = grid;
            _height = grid.GetLength(0);
            _width = grid.GetLength(1);
        }

        public IReadOnlyList<int> GetColumn(int x) => new GridColumn(_grid, x);

        public IReadOnlyList<int> GetRow(int y) => new GridRow(_grid, y);

        private class GridRow : IReadOnlyList<int>
        {
            private readonly int[,] _grid;
            private readonly int _y;

            public GridRow(int[,] grid, int index)
            {
                _grid = grid;
                _y = index;
            }

            public int this[int index] => _grid[_y, index];

            public int Count => _grid.GetLength(0);

            public IEnumerator<int> GetEnumerator()
            {
                int length = Count;
                for (int i = 0; i < length; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class GridColumn : IReadOnlyList<int>
        {
            private readonly int[,] _grid;
            private readonly int _x;
            public GridColumn(int[,] grid, int index)
            {
                _grid = grid;
                _x = index;
            }

            public int this[int index] => _grid[index, _x];

            public int Count => _grid.GetLength(1);

            public IEnumerator<int> GetEnumerator()
            {
                int length = Count;
                for (int i = 0; i < length; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
