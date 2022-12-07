namespace AdventOfCode2022.Day7
{
    internal class Directory : FileSystemNode 
    {
        private Dictionary<string, FileSystemNode> _children = new();

        public IEnumerable<FileSystemNode> Children => _children.Values;

        public Directory(string name) : base(name)
        {
        }

        public void Add(File file) => _children.Add(file.Name, file);

        public void Add(Directory directory) => _children.Add(directory.Name, directory);

        public Directory? GetChildDirectory(string name)
        {
            if (_children.TryGetValue(name, out FileSystemNode? node) && node is Directory childDirectory)
            {
                return childDirectory;
            }

            return null;
        }
    }
}
