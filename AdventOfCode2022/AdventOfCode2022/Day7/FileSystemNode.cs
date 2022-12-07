namespace AdventOfCode2022.Day7
{
    internal abstract class FileSystemNode
    {
        public string Name { get; }

        public FileSystemNode(string name)
        {
            Name = name;
        }
    }
}
