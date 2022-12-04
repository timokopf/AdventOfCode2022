namespace AdventOfCode2022.Day4
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            (Range firstRange, Range secondRange)[] rangePairs = Array.ConvertAll(input, ParseRangePairInput);

            return rangePairs.Count(rangePair => rangePair.firstRange.Contains(rangePair.secondRange) || rangePair.secondRange.Contains(rangePair.firstRange));
        }

        public int SolvePart2(string[] input)
        {
            (Range firstRange, Range secondRange)[] rangePairs = Array.ConvertAll(input, ParseRangePairInput);

            return rangePairs.Count(rangePair => rangePair.firstRange.OverlapsWith(rangePair.secondRange));
        }

        private static (Range firstRange, Range secondRange) ParseRangePairInput(string input)
        {
            var split = input.Split(',', StringSplitOptions.TrimEntries);
            string[] firstRangeSplit = split[0].Split('-');
            string[] secondRangeSplit = split[1].Split('-');

            var firstRange = new Range(int.Parse(firstRangeSplit[0]), int.Parse(firstRangeSplit[1]));
            var secondRange = new Range(int.Parse(secondRangeSplit[0]), int.Parse(secondRangeSplit[1]));

            return (firstRange, secondRange);
        }
    }
}
