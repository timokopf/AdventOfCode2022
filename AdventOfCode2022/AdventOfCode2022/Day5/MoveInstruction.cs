using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day5
{
    internal readonly partial record struct MoveInstruction
    {
        private static readonly Regex moveMatcher = MoveInstructionMatcher();

        public int Count { get; }
        public int From { get; }
        public int To { get; }

        public MoveInstruction(int count, int from, int to)
        {
            Count = count;
            From = from;
            To = to;
        }

        public static MoveInstruction Parse(string moveInstruction)
        {
            Match match = moveMatcher.Match(moveInstruction);
            int amount = int.Parse(match.Groups[1].ValueSpan);
            int from = int.Parse(match.Groups[2].ValueSpan) - 1;
            int to = int.Parse(match.Groups[3].ValueSpan) - 1;

            return new MoveInstruction(amount, from, to);
        }

        [GeneratedRegex("move (\\d+) from (\\d+) to (\\d+)")]
        private static partial Regex MoveInstructionMatcher();
    }
}
