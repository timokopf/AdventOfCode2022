namespace AdventOfCode2022.Day1
{
    public class UnifiedSolution
    {
        public int SolvePart1(string[] input) => CalculateTopNCaloriesPerElve(input, 1);

        public int SolvePart2(string[] input) => CalculateTopNCaloriesPerElve(input, 3);

        private static int CalculateTopNCaloriesPerElve(string[] input, int n)
        {
            PriorityQueue<int, int> topN = new(Enumerable.Repeat(0, n).Select(x => (x, x)));

            int caloriesPerElve = 0;
            foreach (var item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    topN.EnqueueDequeue(caloriesPerElve, caloriesPerElve);
                    caloriesPerElve = 0;
                    continue;
                }

                caloriesPerElve += int.Parse(item);
            }

            return topN.UnorderedItems.Sum(x => x.Element);
        }
    }
}
