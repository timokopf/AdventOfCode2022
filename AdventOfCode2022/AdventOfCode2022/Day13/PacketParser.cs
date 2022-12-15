using System.Diagnostics;

namespace AdventOfCode2022.Day13
{
    internal static class PacketParser
    {
        public static Packet Parse(string packetInput)
        {
            Packet result = new Packet();
            int position = 0;
            result.Values = ParseList(packetInput, ref position);

            return result;
        }

        private static List ParseList(string packetInput, ref int position)
        {
            position++;
            List<Value> values = new();
            while (position < packetInput.Length && packetInput[position] != ']') 
            {
                Value? v;
                if (char.IsDigit(packetInput[position]))
                {
                    v = ParseInteger(packetInput, ref position);
                } else if (packetInput[position] == '[') 
                {
                    v = ParseList(packetInput, ref position);
                } else if (packetInput[position] == ',')
                {
                    position++;
                    continue;
                }
                else
                {
                    throw new UnreachableException();
                }

                values.Add(v!);
            }

            position++;

            return new List(values);
        }

        private static Integer ParseInteger(string packetInput, ref int position)
        {
            int value = 0;
            while (char.IsDigit(packetInput[position]))
            {
                value = value * 10 + (packetInput[position] - '0');

                position++;
            }

            return new Integer(value);
        }
    }
}