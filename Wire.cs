using System;
using System.Collections.Generic;
using System.Globalization;
using AdventOfCode_2019.Mathematics;

namespace AdventOfCode_2019
{
    public class Wire
    {
        // A cache of all this wires coordinates + thei index in the chain
        public Dictionary<int2, int> coordinates = new Dictionary<int2, int>();

        public Wire(string pathData)
        {
            ParsePathData(pathData);
        }

        private void ParsePathData(string pathData)
        {
            string[] offsets = pathData.Split(',');

            int2 lastCoordinate = new int2();
            int coordinateIndex = 1;
            for (int i = 0; i < offsets.Length; i++)
            {
                lastCoordinate = ParseCoordinateOffset(lastCoordinate, ref coordinateIndex, offsets[i]);
            }
        }  

        private int2 ParseCoordinateOffset(int2 previous, ref int index, string offsetString)
        {
            char directionChar = offsetString[0];
            string amountString = offsetString.Substring(1, offsetString.Length - 1);

            if (!int.TryParse(amountString, NumberStyles.Any, null, out int offset))
                throw new Exception($"Could not pares string {amountString} as an Integer");

            int2 direction = GetDirection(directionChar);
            for (int i = 0; i < offset; i++)
            {
                previous = previous + direction;
                if (!coordinates.ContainsKey(previous))
                    coordinates.Add(previous, index);
                index++;
            }
            return previous;
        }

        private int2 GetDirection(char character)
        {
            switch (character)
            {
                default:
                case 'U':
                return new int2(0, 1);
                
                case 'R':
                return new int2(1, 0);
                
                case 'D':
                return new int2(0, -1);
                
                case 'L':
                return new int2(-1, 0);
            }
        }
    }
}