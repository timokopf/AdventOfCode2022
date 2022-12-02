using AdventOfCode.Inputs;
using AdventOfCode2022.Day2;

namespace AdventOfCode2022.Tests.Day2
{
    internal class SolutionTest
    {
        private readonly string[] _input = Inputs.Day2;

        [Test]
        public void SolvePart1()
        {
            int totalScore = new Solution().SolvePart1(_input);

            Assert.That(totalScore, Is.EqualTo(10718));
        }

        [Test]
        public void SolvePart2()
        {
            int totalScore = new Solution().SolvePart2(_input);

            Assert.That(totalScore, Is.EqualTo(14652));
        }
    }
}
