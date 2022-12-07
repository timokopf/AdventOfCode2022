using AdventOfCode.Inputs;
using AdventOfCode2022.Day7;

namespace AdventOfCode2022.Tests.Day7
{
    internal class SolutionTest
    {
        private static readonly string[] _input = Inputs.Instance.Day7;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(1915606));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Assert.That(result, Is.EqualTo(5025657));
        }
    }
}
