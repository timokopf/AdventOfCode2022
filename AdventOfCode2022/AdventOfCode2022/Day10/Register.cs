namespace AdventOfCode2022.Day10
{
    internal readonly struct Register
    {
        private readonly int _value;

        public static implicit operator Register(int value) => new Register(value);
        public static implicit operator int(Register @this) => @this._value;

        public Register(int value)
        {
            _value = value;
        }
    }
}
