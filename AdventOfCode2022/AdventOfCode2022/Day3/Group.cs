namespace AdventOfCode2022.Day3
{
    internal class Group
    {
        private readonly Rucksack[] _rucksacks;

        public Group(ArraySegment<string> rucksacks)
        {
            _rucksacks = rucksacks.Select(Rucksack.ParseInput).ToArray();
        }

        public IEnumerable<char> IntersectRucksacks()
        {
            HashSet<char> set = new(_rucksacks[0].Items);

            List<char> intersection = new();
            foreach (var rucksack in _rucksacks.Skip(1))
            {
                foreach (var item in rucksack.Items)
                {
                    if (set.Remove(item))
                    {
                        intersection.Add(item);
                    }
                }

                set = new(intersection);
                intersection.Clear();
            }

            return set;
        }
    }
}
