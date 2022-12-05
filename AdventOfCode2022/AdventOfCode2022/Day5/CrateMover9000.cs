namespace AdventOfCode2022.Day5
{
    internal class CrateMover9000 : Crane
    {
        public override void MoveCranes(IEnumerable<MoveInstruction> moves, CrateStack[] stacks)
        {
            foreach (var move in moves)
            {
                CrateStack origin = stacks[move.From];
                CrateStack target = stacks[move.To];

                for (int n = 0; n < move.Count; n++)
                {
                    char movedCrate = origin.Pop();
                    target.Push(movedCrate);
                }
            }
        }
    }
}
