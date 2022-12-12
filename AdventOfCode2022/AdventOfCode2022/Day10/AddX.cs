namespace AdventOfCode2022.Day10
{
    internal class AddX : Instruction
    {
        public int Operand { get; }

        public override int Cycles => 2;

        public AddX(int operand)
        {
            Operand = operand;
        }

    }
}
