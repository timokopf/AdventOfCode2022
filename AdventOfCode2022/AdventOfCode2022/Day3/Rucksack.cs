namespace AdventOfCode2022.Day3
{
    internal class Rucksack
    {
        private readonly string _items;

        public string Items => _items;

        private Rucksack(string items)
        {
            _items = items;
        }

        public static Rucksack ParseInput(string input)
        {
            return new Rucksack(input);
        }

        public IEnumerable<char> IntersectCompartments()
        {
            var firstCompartment = _items.AsSpan()[..(_items.Length / 2)];
            var secondCompartment = _items.AsSpan()[(_items.Length / 2)..];

            HashSet<char> set = new();
            foreach (var item in firstCompartment)
            {
                set.Add(item);
            }

            List<char> intersection = new();
            foreach (var item in secondCompartment)
            {
                if (set.Remove(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }
    }
}