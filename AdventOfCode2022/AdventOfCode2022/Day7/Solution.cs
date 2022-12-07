namespace AdventOfCode2022.Day7
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            IEnumerator<string> inputEnumerator = ((IEnumerable<string>)input).GetEnumerator();
            inputEnumerator.MoveNext();
            Directory slash = new Directory("/");
            BuildFileSystemTree(inputEnumerator, slash);

            Dictionary<Directory, int> directorySizes = new DirectorySizeCollector(slash).Collect();
            return directorySizes.Where(x => x.Value <= 100000).Sum(x => x.Value);
        }

        public int SolvePart2(string[] input)
        {
            IEnumerator<string> inputEnumerator = ((IEnumerable<string>)input).GetEnumerator();
            inputEnumerator.MoveNext();
            Directory slash = new Directory("/");
            BuildFileSystemTree(inputEnumerator, slash);

            Dictionary<Directory, int> directorySizes = new DirectorySizeCollector(slash).Collect();
            int atLeast = directorySizes[slash] - (70_000_000 - 30_000_000);
            return directorySizes.Where(x => x.Value >= atLeast).Min(x => x.Value);
        }

        private static void BuildFileSystemTree(IEnumerator<string> input, Directory currentDirectory)
        {
            while (input.MoveNext())
            {
                bool dontMoveNext = true;
                while (dontMoveNext)
                {
                    string current = input.Current;
                    if (current == "$ ls")
                    {
                        bool endOfStream = AddChildrenTo(input, currentDirectory);
                        if (endOfStream)
                        {
                            return;
                        }
                    }
                    else if (current.StartsWith("$ cd"))
                    {
                        string targetDir = current[5..];
                        if (targetDir == "..")
                        {
                            return;
                        }

                        Directory childDirectory = currentDirectory.GetChildDirectory(targetDir)!;
                        BuildFileSystemTree(input, childDirectory);
                        dontMoveNext = false;
                    }
                    else
                    {
                        dontMoveNext = false;
                    }
                }
            }
        }

        private static bool AddChildrenTo(IEnumerator<string> input, Directory directory)
        {
            while (input.MoveNext())
            {
                if (input.Current[0] == '$')
                {
                    return false;
                }

                if (input.Current.StartsWith("dir"))
                {
                    directory.Add(new Directory(input.Current[4..]));
                }
                else
                {
                    int splitIndex = input.Current.IndexOf(' ');
                    int size = int.Parse(input.Current[..splitIndex]);
                    string name = input.Current[(splitIndex + 1)..];
                    directory.Add(new File(name, size));
                }
            }

            return true;
        }
    }
}
