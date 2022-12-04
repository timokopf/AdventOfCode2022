using AdventOfCode.Inputs;
using AdventOfCode2022.Day3;

namespace AdventOfCode2022.Tests.Day3
{
    internal class SolutionTests
    {
        private static string[] _input = Inputs.Day3;
        
        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(7793));
        }

        [Test]
        public void SolvePart2()
        {
            int result = new Solution().SolvePart2(_input);

            Assert.That(result, Is.EqualTo(2499));
        }
    }
}
