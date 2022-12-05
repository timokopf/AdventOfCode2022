namespace AdventOfCode2022.Day5
{
    internal abstract class Crane
    {
        public abstract void MoveCranes(IEnumerable<MoveInstruction> moves, CrateStack[] stacks);
    }
}
