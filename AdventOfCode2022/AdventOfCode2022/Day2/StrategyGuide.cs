namespace AdventOfCode2022.Day2
{
    internal class StrategyGuide
    {
        private readonly IReadOnlyList<Round> _rounds;

        public StrategyGuide(IReadOnlyList<Round> rounds)
        {
            _rounds = rounds;
        }

        public int Execute() => _rounds.Sum(round => round.CalculateScore());
    }
}
