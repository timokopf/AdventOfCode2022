namespace AdventOfCode2022.Day5
{
    public class Solution
    {
        public string SolvePart1(ArraySegment<string> input)
        {
            CrateStack[] stacks = ParseStacks(input, out int maxStackSize);
            IEnumerable<MoveInstruction> moveInstructions = input[(maxStackSize + 2)..].Select(MoveInstruction.Parse);

            Crane crane = new CrateMover9000();
            crane.MoveCranes(moveInstructions, stacks);

            return string.Join("", stacks.Select(stack => stack.Peek()));
        }

        public string SolvePart2(ArraySegment<string> input)
        {
            CrateStack[] stacks = ParseStacks(input, out int maxStackSize);
            IEnumerable<MoveInstruction> moveInstructions = input[(maxStackSize + 2)..].Select(MoveInstruction.Parse);

            Crane crane = new CrateMover9001();
            crane.MoveCranes(moveInstructions, stacks);

            return string.Join("", stacks.Select(stack => stack.Peek()));
        }

        private static CrateStack[] ParseStacks(ArraySegment<string> input, out int maxStackSize)
        {
            IEnumerable<string> crateRowStrings = input.TakeWhile(input => input.Length > 0).SkipLast(1);
            char[][] crateRows = crateRowStrings.Select(ParseCrateRow).ToArray();
            CrateStack[] stacks = BuildStacks(crateRows);

            maxStackSize = crateRows.Length;
            return stacks;
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

        private static CrateStack[] BuildStacks(char[][] crateRows)
        {
            CrateStack[] stacks = new CrateStack[crateRows[0].Length];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new CrateStack();
            }

            for (int x = 0; x < crateRows[0].Length; x++)
            {
                CrateStack stack = stacks[x];
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
    }
}
