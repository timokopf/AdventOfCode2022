using System.Diagnostics;

namespace AdventOfCode2022.Day9
{
    internal class Motion
    {
        private readonly Direction _direction;
        private readonly int _steps;

        public int Steps => _steps;
        public Direction Direction => _direction;

        public Motion(Direction direction, int steps)
        {
            _direction = direction;
            _steps = steps;
        }

        public static Motion ParseInput(string input)
        {
            Direction direction = input[0] switch
            {
                'D' => Direction.Down,
                'L' => Direction.Left,
                'U' => Direction.Up,
                'R' => Direction.Right,
                _ => throw new UnreachableException()
            };
            int steps = int.Parse(input[2..]);

            return new Motion(direction, steps);
        }
    }
}
