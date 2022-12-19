using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day15
{
    public partial class Solution
    {
        public int SolvePart1(string[] input, int row)
        {
            Sensor[] sensors = Array.ConvertAll(input, ParseSensorInput);

            return SolvePart1(sensors, row);
        }

        public int SolvePart1(Sensor[] sensors, int row) => GetSensorCoverageOnRow(sensors, row).Sum(i => i.To - i.From);

        public long SolvePart2(string[] input, (Point topLeft, Point bottomRight) searchSpace)
        {
            Sensor[] sensors = Array.ConvertAll(input, ParseSensorInput);

            for (int row = searchSpace.topLeft.Y; row <= searchSpace.bottomRight.Y; row++)
            {
                List<Interval> rowCoverage = GetSensorCoverageOnRow(sensors, row);
                if (rowCoverage.Count == 1)
                {
                    continue;
                }

                long xPosDistressBeacon = rowCoverage[0].To + 1;
                long yPosDistressBeacon = row;
                long tuningFrequency = xPosDistressBeacon * 4000000 + yPosDistressBeacon;

                return tuningFrequency;
            }

            throw new UnreachableException();
        }

        private static List<Interval> GetSensorCoverageOnRow(Sensor[] sensors, int row)
        {
            List<Interval> intervals = new();
            foreach (var sensor in sensors)
            {
                int distanceToRow = int.Abs(row - sensor.Location.Y);
                int radiusOnRow = sensor.ClosestBeaconRadius - distanceToRow;
                if (radiusOnRow < 0)
                {
                    continue;
                }

                int xCenter = sensor.Location.X;

                var interval = new Interval(xCenter - radiusOnRow, xCenter + radiusOnRow);
                intervals.Add(interval);
            }

            intervals = intervals.OrderBy(i => i.From).ToList();

            List<Interval> mergedIntervals = new();
            foreach (var interval in intervals)
            {
                if (mergedIntervals.Count == 0)
                {
                    mergedIntervals.Add(interval);
                    continue;
                }

                Interval last = mergedIntervals[^1];
                if (interval.From - last.To <= 1)
                {
                    // merge
                    mergedIntervals[^1] = new Interval(last.From, int.Max(last.To, interval.To));
                }
                else
                {
                    mergedIntervals.Add(interval);
                }
            }

            return mergedIntervals;
        }

        [GeneratedRegex(@"Sensor at x=(-?\d+), y=(-?\d+): closest beacon is at x=(-?\d+), y=(-?\d+)")]
        private static partial Regex InputRegex();
        public static Sensor ParseSensorInput(string sensorInput)
        {
            var groups = InputRegex().Match(sensorInput).Groups;
            return new Sensor(int.Parse(groups[1].ValueSpan), int.Parse(groups[2].ValueSpan), new Beacon(int.Parse(groups[3].ValueSpan), int.Parse(groups[4].ValueSpan)));
        }
    }
}
