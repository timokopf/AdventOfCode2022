using AdventOfCode.Inputs;
using AdventOfCode2022.Day8;
using System.Collections;

namespace AdventOfCode2022.Tests.Day8
{
    internal class SolutionTest
    {
        private static readonly string[] _sampleInput = """
            30373
            25512
            65332
            33549
            35390
            """.Split('\n', StringSplitOptions.TrimEntries);
        private static readonly string[] _input = Inputs.Instance.Day8;
        
        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(1827));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Assert.That(result, Is.EqualTo(335580));
        }

        [Test]
        public void FindSinks()
        {
            BitArray result = Solution.FindSinks(new[] { 2, 5, 5, 1, 2 });

            BitArray expected = new BitArray(new[] { false, false, false, true, false });

            Assert.That(result.Xor(expected).Not().OfType<bool>().All(x => x));
        }

        [Test]
        public void TrialWithSample()
        {
            int result = new Solution().SolvePart1(_sampleInput);

            Assert.That(result, Is.EqualTo(21));
        }
    }
}
