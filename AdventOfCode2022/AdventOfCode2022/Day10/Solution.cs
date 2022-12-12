namespace AdventOfCode2022.Day10
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            Instruction[] instructions = Array.ConvertAll(input, Instruction.Parse);

            CPU cpu = new CPU(instructions);
            SignalStrengthObserver signalStrengthObserver = new SignalStrengthObserver(cpu);
            ClockCircuit clock = new ClockCircuit(cpu, signalStrengthObserver);

            while (clock.Tick())
            {
            }

            return signalStrengthObserver.GetObservedSignalStrengths().Take(6).Sum();
        }

        public char[,] SolvePart2(string[] input)
        {
            Instruction[] instructions = Array.ConvertAll(input, Instruction.Parse);

            CPU cpu = new CPU(instructions);
            CRT crt = new CRT(x => x >= cpu.X - 1 && x <= cpu.X + 1);
            ClockCircuit clock = new ClockCircuit(crt, cpu);

            while (clock.Tick())
            {
            }

            return crt.Display;
        }
    }

    internal class CRT : ITickListener
    {
        private readonly int _width = 40;
        private readonly int _height = 6;
        private readonly Predicate<int> _shouldDrawPixel;
        private int _position = 0;

        public char[,] Display { get; }

        public CRT(Predicate<int> shouldDrawPixel)
        {
            Display = new char[_height, _width];
            this._shouldDrawPixel = shouldDrawPixel;
        }

        public bool NotifyTick()
        {
            int posY = _position / _width;
            int posX = _position % _width;

            Display[posY, posX] = _shouldDrawPixel(posX) ? '#' : '.';
            
            _position = (_position + 1) % (_width * _height);

            return true;
        }
    }
}
