using System;
using System.IO;
using System.Globalization;

namespace AdventOfCode_2019.Day1
{
    public class CorrectedFuelCounter
    {
        private int[] inputData;

        public void LoadInputData(string localPath)
        {
            string[] lines = File.ReadAllLines(FileUtility.GetApplicationPath() + localPath);
            inputData = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                bool success = int.TryParse(lines[i], NumberStyles.Integer, null, out int result);
                if (success)
                    inputData[i] = result;
                else
                    throw new Exception($"Could not parse string {lines[i]}");
            }
        }

        public int CalculateFuelRequirement()
        {
            if (inputData == null)
                throw new Exception("Input data was not loaded!");

            int result = 0;
            foreach (int value in inputData)
            {
                int fuel = (value / 3) - 2;
                while (fuel > 0)
                {
                    result += fuel;
                    fuel = (fuel / 3) - 2;
                }
            }

            return result;
        }
    }
}