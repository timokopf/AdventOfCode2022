using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day5
{
    public class Solution
    {
        public string SolvePart1(string[] input)
        {
            IEnumerable<string> crateRowStrings = input.TakeWhile(input => input.Length > 0).SkipLast(1);
            char[][] crateRows = crateRowStrings.Select(ParseCrateRow).ToArray();
            Stack<char>[] stacks = BuildStacks(crateRows);

            IEnumerable<string> moveInstructions = input.SkipWhile(input => input.Length > 0).Skip(1);
            IEnumerable<Move> moves = moveInstructions.Select(Move.Parse);

            ExecuteMoves(moves, stacks);

            return string.Join("", stacks.Select(stack => stack.Peek()));
        }

        private static char[] ParseCrateRow(string crateRow)
        {
            char[] crates = new char[crateRow.Length / 4 + 1];
            for (int i = 0; i < crateRow.Length / 4 + 1; i++)
            {
                char crate = crateRow[i * 4 + 1];
                crates[i] = crate;
            }

            return crates;
        }

        private static Stack<char>[] BuildStacks(char[][] crateRows)
        {
            Stack<char>[] stacks = new Stack<char>[crateRows[0].Length];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>();
            }

            for (int x = 0; x < crateRows[0].Length; x++)
            {
                Stack<char> stack = stacks[x];
                for (int y = crateRows.Length - 1; y >= 0; y--)
                {
                    char crate = crateRows[y][x];
                    if (crate != ' ')
                    {
                        stack.Push(crate);
                    }
                }
            }

            return stacks;
        }

        private static void ExecuteMoves(IEnumerable<Move> moves, Stack<char>[] stacks)
        {
            foreach (var move in moves)
            {
                move.Execute(stacks);
            }
        }
    }

    internal partial class Move
    {
        private static readonly Regex moveMatcher = MoveInstructionMatcher();
        private int _amount;
        private int _from;
        private int _to;

        public Move(int amount, int from, int to)
        {
            _amount = amount;
            _from = from;
            _to = to;
        }

        public static Move Parse(string moveInstruction)
        {
            Match match = moveMatcher.Match(moveInstruction);
            int amount = int.Parse(match.Groups[1].ValueSpan);
            int from = int.Parse(match.Groups[2].ValueSpan) - 1;
            int to = int.Parse(match.Groups[3].ValueSpan) - 1;

            return new Move(amount, from, to);
        }

        public void Execute(Stack<char>[] stacks)
        {
            Stack<char> moveOrigin = stacks[_from];
            Stack<char> moveTarget = stacks[_to];

            for (int n = 0; n < _amount; n++)
            {
                char movedCrate = moveOrigin.Pop();
                moveTarget.Push(movedCrate);
            }
        }

        [GeneratedRegex("move (\\d+) from (\\d+) to (\\d+)")]
        private static partial Regex MoveInstructionMatcher();
    }
}
