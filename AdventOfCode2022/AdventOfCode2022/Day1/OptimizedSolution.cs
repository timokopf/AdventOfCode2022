using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode2022.Day1
{
    public class OptimizedSolution
    {
        public int SolvePart1(string[] input)
        {
            int maxCalories = 0;

            int calories = 0;
            ref string searchSpace = ref MemoryMarshal.GetReference(input.AsSpan());
            for (int i = 0; i < input.Length; i++)
            {
                string item = Unsafe.Add(ref searchSpace, i);
                if (string.IsNullOrEmpty(item))
                {
                    maxCalories = Math.Max(maxCalories, calories);
                    calories = 0;
                    continue;
                }

                calories += int.Parse(item);
            }

            return maxCalories;
        }

        public int SolvePart2(string[] input)
        {
            PriorityQueue<int, int> topThree = new();
            topThree.Enqueue(0, 0);
            topThree.Enqueue(0, 0);
            topThree.Enqueue(0, 0);

            int caloriesPerElve = 0;
            ref string searchSpace = ref MemoryMarshal.GetReference(input.AsSpan());
            for (int i = 0; i < input.Length; i++)
            {
                string item = Unsafe.Add(ref searchSpace, i);
                if (string.IsNullOrEmpty(item))
                {
                    topThree.EnqueueDequeue(caloriesPerElve, caloriesPerElve);
                    caloriesPerElve = 0;
                    continue;
                }

                caloriesPerElve += int.Parse(item);
            }

            return topThree.UnorderedItems.Sum(x => x.Element);
        }
    }
}
