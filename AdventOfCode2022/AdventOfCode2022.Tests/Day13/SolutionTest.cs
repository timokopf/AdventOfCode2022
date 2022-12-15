using AdventOfCode.Inputs;
using AdventOfCode2022.Day13;

namespace AdventOfCode2022.Tests.Day13
{
    internal class SolutionTest
    {
        private static readonly string[] _input = Inputs.Instance.Day13;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(5682));
        }

        [Test]
        public void SolvePart1Sample() 
        {
            int result = new Solution().SolvePart1(_sampleInput);

            Assert.That(result, Is.EqualTo(13));
        }

        [Test]
        public void SolvePart2Sample()
        {
            int result = new Solution().SolvePart2(_sampleInput);

            Assert.That(result, Is.EqualTo(140));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Assert.That(result, Is.EqualTo(20304));
        }

        private static readonly string[] _sampleInput = """
            [1,1,3,1,1]
            [1,1,5,1,1]

            [[1],[2,3,4]]
            [[1],4]

            [9]
            [[8,7,6]]

            [[4,4],4,4]
            [[4,4],4,4,4]

            [7,7,7,7]
            [7,7,7]

            []
            [3]

            [[[]]]
            [[]]

            [1,[2,[3,[4,[5,6,7]]]],8,9]
            [1,[2,[3,[4,[5,6,0]]]],8,9]
            """.Split('\n', StringSplitOptions.TrimEntries);
    }
}
