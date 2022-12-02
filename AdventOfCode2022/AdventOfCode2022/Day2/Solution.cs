namespace AdventOfCode2022.Day2
{
    public partial class Solution
    {
        public int SolvePart1(string[] input)
        {
            StrategyGuide strategy = new(ParseInput(input));
            int myTotalScore = strategy.Execute();

            return myTotalScore;

            static Round[] ParseInput(string[] input) => Array.ConvertAll(input, Round.ParseInputLine);
        }

        public int SolvePart2(string[] input)
        {
            StrategyGuide strategy = new(ParseInput(input));
            int myTotalScore = strategy.Execute();

            return myTotalScore;

            static Round[] ParseInput(string[] input) => Array.ConvertAll(input, line => Move.ParseInputLine(line).Play());
        }
    }
}
