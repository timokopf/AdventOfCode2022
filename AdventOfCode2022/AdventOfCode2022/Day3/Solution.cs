namespace AdventOfCode2022.Day3
{
    public partial class Solution
    {
        public int SolvePart1(string[] input)
        {
            Rucksack[] rucksacks = Array.ConvertAll(input, Rucksack.ParseInput);

            int sumOfPriorities = rucksacks.SelectMany(r => r.IntersectCompartments()).Sum(ToPriority);

            return sumOfPriorities;
        }

        public int SolvePart2(string[] input)
        {
            Group[] groups = ChunkIntoGroupsOfThree(input);
            int sumOfPriorities = groups.SelectMany(g => g.IntersectRucksacks()).Sum(ToPriority);
            return sumOfPriorities;
        }

        private static Group[] ChunkIntoGroupsOfThree(string[] input)
        {
            var groups = new Group[input.Length / 3];

            for (int i = 0; i < input.Length / 3; i++)
            {
                groups[i] = new Group(new ArraySegment<string>(input, i * 3, 3));
            }

            return groups;
        }

        private static int ToPriority(char itemType) => itemType switch
        {
            >= 'a' and <= 'z' => itemType - 'a' + 1,
            >= 'A' and <= 'Z' => itemType - 'A' + 27,
            _ => throw new NotSupportedException()
        };
    }
}
