using System.Diagnostics;

namespace AdventOfCode2022.Day6
{
    public class Solution
    {
        public int SolvePart1(string input) => FindIndexOfFirstDistinctSubstring(input, 4);

        public int SolvePart2(string input) => FindIndexOfFirstDistinctSubstring(input, 14);

        private int FindIndexOfFirstDistinctSubstring(string input, int substringLength) 
        {
            Dictionary<char, int> slidingWindow = new();
            for (int i = 0; i < substringLength; i++)
            {
                char c = input[i];
                if (slidingWindow.TryAdd(c, 1) is false)
                {
                    slidingWindow[c]++;
                }
            }

            for (int i = substringLength; i < input.Length; i++)
            {
                if (slidingWindow.Count == substringLength)
                {
                    return i;
                }

                char lastInWindow = input[i - substringLength];
                if (slidingWindow[lastInWindow] == 1)
                {
                    slidingWindow.Remove(lastInWindow);
                }
                else
                {
                    slidingWindow[lastInWindow]--;
                }

                char next = input[i];
                if (slidingWindow.TryAdd(next, 1) is false)
                {
                    slidingWindow[next]++;
                }
            }

            throw new UnreachableException();
        }
    }
}
