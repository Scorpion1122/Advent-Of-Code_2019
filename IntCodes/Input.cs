using System.Collections.Generic;

namespace AdventOfCode_2019.IntCodes
{
    public class Input
    {
        private List<int> values = new List<int>();
        private int currentValueIndex = 0;

        public void AddValue(int value)
        {
            values.Add(value);
        }

        public bool HasNextValue()
        {
            return currentValueIndex < values.Count;
        }

        public int GetNextValue()
        {
            currentValueIndex++;
            return values[currentValueIndex - 1];
        }

        public void Reset()
        {
            values.Clear();
            currentValueIndex = 0;
        }
    }
}