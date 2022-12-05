using AdventOfCode.Inputs;
using AdventOfCode2022.Day5;

namespace AdventOfCode2022.Tests.Day5
{
    internal class SolutionTests
    {
        private static readonly string[] _input = Inputs.Instance.Day5;
        [Test]
        public void SolvePart1()
        {
            string result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo("TDCHVHJTG"));
        }
    }
}
