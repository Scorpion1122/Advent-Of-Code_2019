using System.Collections.Generic;
using AdventOfCode_2019.IntCodes;

namespace AdventOfCode_2019
{
    public class Amplifier
    {
        private int[] phaseSettings;
        private List<int[]> phaseCombinations = new List<int[]>();

        public void SetPhaseSettings(int[] phaseSettings)
        {
            this.phaseSettings = phaseSettings;
            phaseCombinations.Clear();
            ProcessAllCombinations(phaseSettings, new int[phaseSettings.Length], 0, phaseCombinations);
        }

        private void ProcessAllCombinations(int[] input, int[] data, int index, List<int[]> combinations)
        {
            if (index >= data.Length)
            {
                combinations.Add((int[])data.Clone());
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i];
                bool uniqueValue = true;
                for (int j = index - 1; j >= 0; j--)
                {
                    if (data[j] == value)
                    {
                        uniqueValue = false;
                        break;
                    }
                }

                if (uniqueValue)
                {
                    data[index] = value;
                    ProcessAllCombinations(input, data, index + 1, combinations);
                }
            }   
        }

        public int GetHighestOutputValue()
        {
            int result = 0;
            foreach (var phaseSetting in phaseCombinations)
            {
                int output = RunAmplifiers(phaseSetting);
                if (output > result)
                    result = output;
            }
            return result;
        }

        private int RunAmplifiers(int[] inputs)
        {
            IntCodeSolver solver = new IntCodeSolver();

            IntCode intCode = new IntCode();
            intCode.LoadDataFromPath("data/day7_puzzle_input.txt");

            Input presetInput = new Input();
            solver.PresetInput = presetInput;

            int previousOutput = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                presetInput.Reset();
                presetInput.AddValue(inputs[i]);
                presetInput.AddValue(previousOutput);

                IntCode copy = intCode.CreateCopy();
                solver.SetIntCode(copy);
                solver.StepAll();
                previousOutput = solver.Output;
            }
            return previousOutput;
        }
    }
}