using AdventOfCode.Inputs;
using AdventOfCode2022.Day15;

namespace AdventOfCode2022.Tests.Day15
{
    internal class SolutionTest
    {
        private static readonly string[] _input = Inputs.Instance.Day15;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input, 2_000_000);

            Assert.That(result, Is.EqualTo(6275922));
        }

        [Test]
        public void SolvePart1Sample()
        {
            int result = new Solution().SolvePart1(_sampleInput, 10);

            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void SolvePart2Sample()
        {
            long result = new Solution().SolvePart2(_sampleInput, (new Point(0, 0), new Point(20, 20)));

            Assert.That(result, Is.EqualTo(56000011));
        }

        [Test]
        public void SolvePart2()
        {
            long result = new Solution().SolvePart2(_input, (new Point(0, 0), new Point(4_000_000, 4_000_000)));

            Assert.That(result, Is.EqualTo(11747175442119));
        }

        private static readonly string[] _sampleInput = """
            Sensor at x=2, y=18: closest beacon is at x=-2, y=15
            Sensor at x=9, y=16: closest beacon is at x=10, y=16
            Sensor at x=13, y=2: closest beacon is at x=15, y=3
            Sensor at x=12, y=14: closest beacon is at x=10, y=16
            Sensor at x=10, y=20: closest beacon is at x=10, y=16
            Sensor at x=14, y=17: closest beacon is at x=10, y=16
            Sensor at x=8, y=7: closest beacon is at x=2, y=10
            Sensor at x=2, y=0: closest beacon is at x=2, y=10
            Sensor at x=0, y=11: closest beacon is at x=2, y=10
            Sensor at x=20, y=14: closest beacon is at x=25, y=17
            Sensor at x=17, y=20: closest beacon is at x=21, y=22
            Sensor at x=16, y=7: closest beacon is at x=15, y=3
            Sensor at x=14, y=3: closest beacon is at x=15, y=3
            Sensor at x=20, y=1: closest beacon is at x=15, y=3
            """.Split('\n', StringSplitOptions.TrimEntries);
    }
}
