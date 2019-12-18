using System;
using System.IO;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode_2019.IntCodes
{   
    public class IntCode
    {
        private const char SEPERATOR = ',';

        private List<int> values = new List<int>();

        public int this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }

        public int GetValue(int pointerIndex, ParamMode mode)
        {
            if (mode == ParamMode.Immediate)
                return values[pointerIndex];
            // ParamMode.Position is the default
            return values[values[pointerIndex]];
        }       

        public void WriteValue(int pointerIndex, int value, ParamMode mode)
        {
            if (mode == ParamMode.Immediate)
                values[pointerIndex] = value;
            if (mode == ParamMode.Position)
                values[values[pointerIndex]] = value;
        }

        public void LoadDataFromPath(string dataPath)
        {
            values.Clear();
            LoadFromString(File.ReadAllText(FileUtility.GetApplicationPath() + dataPath));
        }

        public void LoadFromString(string value)
        {
            values.Clear();
            string[] split = value.Split(',');
            for (int i = 0; i < split.Length; i++)
                AddStringToValues(split[i]);
        }

        private void AddStringToValues(string stringNumber)
        {
            if (!int.TryParse(stringNumber, NumberStyles.Any, null, out int number))
                throw new Exception($"String {stringNumber} could not be parsed as a number");
            values.Add(number);
        }

        public IntCode CreateCopy()
        {
            IntCode copy = new IntCode();
            copy.values.AddRange(values);
            return copy;
        }

        public override string ToString()
        {
            return ToString(int.MaxValue);
        }

        public string ToString(int maxRowCount)
        {
            StringBuilder builder = new StringBuilder();
            int rowCount = 0;
            for (int i = 0; i < values.Count; i++)
            {
                if (rowCount == maxRowCount)
                {
                    rowCount = 0;
                    builder.AppendLine();
                }

                builder.Append(values[i]);
                rowCount++;
            }
            return builder.ToString();
        }
    }

}