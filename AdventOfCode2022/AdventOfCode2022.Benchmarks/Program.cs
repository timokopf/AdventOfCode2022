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
}