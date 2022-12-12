using AdventOfCode.Inputs;
using AdventOfCode2022.Day10;

namespace AdventOfCode2022.Tests.Day10
{
    internal class SolutionTest
    {
        private static readonly string[] _input = Inputs.Instance.Day10;

        [Test]
        public void SolvePart1()
        {
            int result = new Solution().SolvePart1(_input);

            Assert.That(result, Is.EqualTo(12880));
        }

        [Test] public void SolvePart2() 
        {
            char[,] result = new Solution().SolvePart2(_input);

            string[] expected = """
                .###..##....##..##..###....##.###..####.
                #....#..#....#.#..#.#..#....#.#..#.#....
                ###..#.......#.#..#.#..#....#.#..#.###..
                #....#.......#.####.###.....#.###..#....
                #....#..#.#..#.#..#.#....#..#.#.#..#....
                #.....##...##..#..#.#.....##..#..#.####.
                """.Split('\n', StringSplitOptions.TrimEntries);

            for (int y = 0; y < result.GetLength(0); y++)
            {
                for (int x = 0; x < result.GetLength(1); x++)
                {
                    Assert.That(result[y, x], Is.EqualTo(expected[y][x]));
                }
            }
        }

        [Test]
        public void SolvePart1WithExample()
        {
            int result = new Solution().SolvePart1(_exampleInput);

            Console.WriteLine(result);
        }

        private static readonly string[] _exampleInput = """
                        addx 15
            addx -11
            addx 6
            addx -3
            addx 5
            addx -1
            addx -8
            addx 13
            addx 4
            noop
            addx -1
            addx 5
            addx -1
            addx 5
            addx -1
            addx 5
            addx -1
            addx 5
            addx -1
            addx -35
            addx 1
            addx 24
            addx -19
            addx 1
            addx 16
            addx -11
            noop
            noop
            addx 21
            addx -15
            noop
            noop
            addx -3
            addx 9
            addx 1
            addx -3
            addx 8
            addx 1
            addx 5
            noop
            noop
            noop
            noop
            noop
            addx -36
            noop
            addx 1
            addx 7
            noop
            noop
            noop
            addx 2
            addx 6
            noop
            noop
            noop
            noop
            noop
            addx 1
            noop
            noop
            addx 7
            addx 1
            noop
            addx -13
            addx 13
            addx 7
            noop
            addx 1
            addx -33
            noop
            noop
            noop
            addx 2
            noop
            noop
            noop
            addx 8
            noop
            addx -1
            addx 2
            addx 1
            noop
            addx 17
            addx -9
            addx 1
            addx 1
            addx -3
            addx 11
            noop
            noop
            addx 1
            noop
            addx 1
            noop
            noop
            addx -13
            addx -19
            addx 1
            addx 3
            addx 26
            addx -30
            addx 12
            addx -1
            addx 3
            addx 1
            noop
            noop
            noop
            addx -9
            addx 18
            addx 1
            addx 2
            noop
            noop
            addx 9
            noop
            noop
            noop
            addx -1
            addx 2
            addx -37
            addx 1
            addx 3
            noop
            addx 15
            addx -21
            addx 22
            addx -6
            addx 1
            noop
            addx 2
            addx 1
            noop
            addx -10
            noop
            noop
            addx 20
            addx 1
            addx 2
            addx 2
            addx -6
            addx -11
            noop
            noop
            noop
            """.Split('\n', StringSplitOptions.TrimEntries);
    }
}
