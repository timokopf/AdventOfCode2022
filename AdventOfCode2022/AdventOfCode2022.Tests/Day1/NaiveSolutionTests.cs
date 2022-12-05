using AdventOfCode.Inputs;
using AdventOfCode2022.Day1;

namespace AdventOfCode2022.Tests.Day1
{
    internal class NaiveSolutionTests
    {
        private readonly string[] _input = Inputs.Instance.Day1;

        [Test]
        public void SolvePart1()
        {
            int mostCalories = new NaiveSolution().SolvePart1(_input);

            Assert.That(mostCalories, Is.EqualTo(69289));
        }

        [Test]
        public void SolvePart2()
        {
            int sumOfTopThree = new NaiveSolution().SolvePart2(_input);

            Assert.That(sumOfTopThree, Is.EqualTo(205615));
        }
    }
}
