namespace AdventOfCode2022.Day15
{
    public class Sensor
    {   
        public Point Location { get; }
        public int ClosestBeaconRadius { get; }

        internal Sensor(int x, int y, Beacon closestBeacon)
        {
            Location = new Point(x, y);
            ClosestBeaconRadius = Point.ManhattenDistance(Location, closestBeacon.Location);
        }
    }
}
