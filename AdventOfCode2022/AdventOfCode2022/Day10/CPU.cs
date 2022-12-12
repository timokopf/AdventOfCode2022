namespace AdventOfCode2022.Day10
{
    internal class CPU : ITickListener
    {
        private int _remainingCylcesOfCurrentExecution = 0;
        private IEnumerator<Instruction> _instructions;
        private Instruction _currentInstruction = new Noop();

        public Register X { get; private set; } = 1;

        public CPU(IEnumerable<Instruction> instructions)
        {
            _instructions = instructions.GetEnumerator();
        }

        public bool NotifyTick()
        {
            bool shouldContinue = NotifyTickInternal();
            _remainingCylcesOfCurrentExecution = Math.Max(0, _remainingCylcesOfCurrentExecution - 1);
            return shouldContinue;
        }

        private bool NotifyTickInternal()
        {
            if (_remainingCylcesOfCurrentExecution == 0)
            {
                if (_instructions.MoveNext() is false)
                {
                    return false;
                }

                BeginExecution(_instructions.Current);
            }

            if (_remainingCylcesOfCurrentExecution == 1)
            {
                CompleteExecution();
            }

            return true;
        }

        private void CompleteExecution()
        {
            switch (_currentInstruction)
            {
                case Noop:
                    break;
                case AddX addx:
                    X += addx.Operand;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private void BeginExecution(Instruction instruction)
        {
            _currentInstruction = instruction;
            _remainingCylcesOfCurrentExecution = instruction.Cycles;
        }
    }
}
