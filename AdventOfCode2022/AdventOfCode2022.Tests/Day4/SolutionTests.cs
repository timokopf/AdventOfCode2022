using AdventOfCode.Inputs;
using AdventOfCode2022.Day4;

namespace AdventOfCode2022.Tests.Day4
{
    internal class SolutionTests
    {
        private static string[] _input = Inputs.Instance.Day4;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(305));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Assert.That(result, Is.EqualTo(811));
        }
    }
}
