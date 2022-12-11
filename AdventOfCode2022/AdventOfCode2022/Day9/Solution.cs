namespace AdventOfCode2022.Day9
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            IEnumerable<Motion> headMotions = ParseInput(input);

            Rope rope = new Rope();
            HashSet<Position> tailPositions = new HashSet<Position> { rope.Tail };

            foreach (var headMotion in headMotions)
            {
                for (int i = 0; i < headMotion.Steps; i++)
                {
                    rope.Move(headMotion.Direction);
                    tailPositions.Add(rope.Tail);
                }
            }

            return tailPositions.Count;
        }

        public int SolvePart2(string[] input)
        {
            IEnumerable<Motion> headMotions = ParseInput(input);

            Rope rope = new Rope(10);
            HashSet<Position> tailPositions = new HashSet<Position> { rope.Tail };

            foreach (var headMotion in headMotions)
            {
                for (int i = 0; i < headMotion.Steps; i++)
                {
                    rope.Move(headMotion.Direction);
                    tailPositions.Add(rope.Tail);
                }
            }

            return tailPositions.Count;
        }

        private static IEnumerable<Motion> ParseInput(string[] input) => Array.ConvertAll(input, Motion.ParseInput);
    }
}
