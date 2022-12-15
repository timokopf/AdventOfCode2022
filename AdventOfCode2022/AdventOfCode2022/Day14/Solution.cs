namespace AdventOfCode2022.Day14
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            RockPath[] rockPaths = ParseRockPaths(input);

            Point sandOrigin = new Point(500, 0);

            Cave cave = Cave.CreateForPart1(rockPaths, sandOrigin);

            int unitsOfSand = 0;
            while (cave.PourSand(sandOrigin))
            {
                unitsOfSand++;
            }

            return unitsOfSand;
        }

        public int SolvePart2(string[] input)
        {
            RockPath[] rockPaths = ParseRockPaths(input);

            Point sandOrigin = new Point(500, 0);

            Cave cave = Cave.CreateForPart2(rockPaths, sandOrigin);

            int unitsOfSand = 0;
            while (cave.PourSand(sandOrigin))
            {
                unitsOfSand++;
            }

            return unitsOfSand;
        }

        private RockPath[] ParseRockPaths(string[] input) => Array.ConvertAll(input, ParseRockPath);
        private RockPath ParseRockPath(string input) => new RockPath(input.Split(" -> ").Select(ParsePoint));
        private Point ParsePoint(string pointInput)
        {
            var split = pointInput.Split(",");

            return new Point(int.Parse(split[0]), int.Parse(split[1]));
        }

        
    }
}
