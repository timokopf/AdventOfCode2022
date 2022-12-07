namespace AdventOfCode2022.Day7
{
    internal class File : FileSystemNode
    {
        public int Size { get; }

        public File(string name, int size) : base(name)
        {
            Size = size;
        }
    }
}
