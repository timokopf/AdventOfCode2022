using AdventOfCode.Inputs;
using AdventOfCode2022.Day14;

namespace AdventOfCode2022.Tests.Day14
{
    internal class SolutionTest
    {
        private static readonly string[] _input = Inputs.Instance.Day14;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Console.WriteLine(result);
        }

        [Test]
        public void SolvePart1Example()
        {
            int result = new Solution().SolvePart1(_sampleInput);

            Console.WriteLine(result);

            Assert.That(result, Is.EqualTo(24));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Console.WriteLine(result);
        }

        [Test]
        public void SolvePart2Example()
        {
            int result = new Solution().SolvePart2(_sampleInput);
            Assert.That(result, Is.EqualTo(93));
        }

        private static readonly string[] _sampleInput = """
            498,4 -> 498,6 -> 496,6
            503,4 -> 502,4 -> 502,9 -> 494,9
            """.Split('\n', StringSplitOptions.TrimEntries);
    }
}
