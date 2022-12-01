namespace AdventOfCode2022.Day1
{
    public class NaiveSolution
    {
        public int SolvePart1(string[] input)
        {
            return ParseInput(input).Max(calories => calories.Sum());
        }

        public int SolvePart2(string[] input)
        {
            return ParseInput(input).Select(calories => calories.Sum()).OrderDescending().Take(3).Sum();
        }

        private List<List<int>> ParseInput(string[] input)
        {
            List<List<int>> foodsByElves = new() { new List<int>() };
            foreach (var item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    foodsByElves.Add(new List<int>());
                    continue;
                }

                foodsByElves.Last().Add(int.Parse(item));
            }

            return foodsByElves;
        }
    }
}
