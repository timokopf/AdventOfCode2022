using AdventOfCode.Inputs;
using AdventOfCode2022.Day12;

namespace AdventOfCode2022.Tests.Day12
{
    internal class SolutionTest
    {
        private static readonly string[] _input = Inputs.Instance.Day12;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(352));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Assert.That(result, Is.EqualTo(345));
        }

        [Test]
        public void SolvePart1Sample()
        {
            int result = new Solution().SolvePart1(_sampleInput);

            Assert.That(result, Is.EqualTo(31));
        }

        private static readonly string[] _sampleInput = """
            Sabqponm
            abcryxxl
            accszExk
            acctuvwj
            abdefghi
            """.Split('\n', StringSplitOptions.TrimEntries);
    }
}
