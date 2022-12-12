namespace AdventOfCode2022.Day10
{
    internal class ClockCircuit
    {
        private readonly ITickListener _listener;

        public ClockCircuit(params ITickListener[] listeners) => _listener = new ListenerAggregate(listeners);

        public bool Tick()
        {
            return _listener.NotifyTick();
        }

        private class ListenerAggregate : ITickListener
        {
            private readonly ITickListener[] _listeners;

            public ListenerAggregate(ITickListener[] listeners) => _listeners = listeners;
            public bool NotifyTick() => Array.TrueForAll(_listeners, listener => listener.NotifyTick());
        }
    }
}
