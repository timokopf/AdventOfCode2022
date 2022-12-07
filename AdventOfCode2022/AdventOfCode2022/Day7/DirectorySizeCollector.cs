namespace AdventOfCode2022.Day7
{
    internal class DirectorySizeCollector
    {
        private readonly Directory _start;

        public DirectorySizeCollector(Directory start)
        {
            _start = start;
        }

        internal Dictionary<Directory, int> Collect()
        {
            Dictionary<Directory, int> collection = new();
            _ = Size(_start, collection);

            return collection;
        }

        private static int Size(Directory directory, Dictionary<Directory, int> collection)
        {
            int size = 0;
            foreach (var child in directory.Children)
            {
                size += child switch
                {
                    Directory childDir => Size(childDir, collection),
                    File childFile => childFile.Size,
                    _ => throw new NotSupportedException()
                };
            }

            collection.Add(directory, size);

            return size;
        }
    }
}