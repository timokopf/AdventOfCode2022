namespace AdventOfCode2022.Day13
{
    public class Solution
    {
        public int SolvePart1(string[] input)
        {
            List<Pair> packetPairs = ParseInput(input).ToList();

            List<int> inRightOrderIndices = packetPairs.Select((pair, index) => (pair, index: index + 1)).Where(x => x.pair.IsInRightOrder()).Select(x => x.index).ToList();
            return inRightOrderIndices.Sum();
        }

        public int SolvePart2(string[] input)
        {
            Packet[] dividerPackets = new[]
            {
                new Packet { Values = new List(new List(new Integer(2))) },
                new Packet { Values = new List(new List(new Integer(6))) }
            };
            IEnumerable<Packet> allPackets = input.Where(line => line.Length > 0).Select(PacketParser.Parse).Concat(dividerPackets);

            List<Packet> inRightOrder = allPackets.Order().ToList();
            int indexOfFirstDividerPacket = inRightOrder.IndexOf(dividerPackets[0]) + 1;
            int indexOfSecondDeviderPacket = inRightOrder.IndexOf(dividerPackets[1]) + 1;

            return indexOfFirstDividerPacket * indexOfSecondDeviderPacket;
        }

        private static IEnumerable<Pair> ParseInput(string[] input)
        {
            IEnumerable<string[]> packetPairInputs = input.Chunk(3);
            foreach (var packetPairInput in packetPairInputs)
            {
                Packet left = PacketParser.Parse(packetPairInput[0]);
                Packet right = PacketParser.Parse(packetPairInput[1]);

                yield return new Pair(left, right);
            }
        }
    }
}
