namespace AdventOfCode2022.Day5
{
    internal class CrateMover9001 : Crane
    {
        public override void MoveCranes(IEnumerable<MoveInstruction> moves, CrateStack[] stacks)
        {
            foreach (var move in moves)
            {
                CrateStack origin = stacks[move.From];
                CrateStack target = stacks[move.To];

                origin.Move(move.Count, target);
            }
        }
    }
}
