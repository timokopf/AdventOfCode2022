namespace AdventOfCode2022.Day10
{
    internal abstract class Instruction
    {
        public abstract int Cycles { get; }
        public static Instruction Parse(string input)
        {
            return input.Split(' ') switch
            {
                ["noop"] => new Noop(),
                ["addx", string operand] => new AddX(int.Parse(operand)),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
