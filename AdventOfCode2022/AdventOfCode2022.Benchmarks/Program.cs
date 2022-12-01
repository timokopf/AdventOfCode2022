using AdventOfCode.Inputs;
using AdventOfCode2022.Day1;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AdventOfCode2022.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Day1Benchmark>();
        }
    }

    public class Day1Benchmark
    {
        private readonly string[] _input = Inputs.Day1;
        private readonly NaiveSolution _naiveSolution = new();
        private readonly OptimizedSolution _optimizedSolution = new();

        [Benchmark]
        public void NaiveSolutionPart1()
        {
            _naiveSolution.SolvePart1(_input);
        }

        [Benchmark]
        public void OptimizedSolutionPart1()
        {
            _optimizedSolution.SolvePart1(_input);
        }

        [Benchmark]
        public void NaiveSolutionPart2()
        {
            _naiveSolution.SolvePart1(_input);
        }

        [Benchmark]
        public void OptimizedSolutionPart2()
        {
            _optimizedSolution.SolvePart2(_input);
        }
    }
}