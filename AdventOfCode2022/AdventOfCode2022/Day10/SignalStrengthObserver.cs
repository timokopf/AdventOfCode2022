namespace AdventOfCode2022.Day10
{
    internal class SignalStrengthObserver : ITickListener
    {
        private readonly CPU _cpu;

        private readonly List<int> _signalStrengths = new();
        private int _cycle = 1;

        public SignalStrengthObserver(CPU cpu) => _cpu = cpu;
        public bool NotifyTick()
        {
            _cycle++;
            if (_cycle == 20 || (_cycle > 20 && ((_cycle - 20) % 40 == 0)))
            {
                _signalStrengths.Add(_cycle * _cpu.X);
            }

            return true;
        }

        public IEnumerable<int> GetObservedSignalStrengths() => _signalStrengths;
    }
}
