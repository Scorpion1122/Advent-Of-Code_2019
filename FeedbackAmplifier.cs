using System.Collections.Generic;
using AdventOfCode_2019.IntCodes;

namespace AdventOfCode_2019
{
    public class FeedbackAmplifier
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
            IntCode intCode = new IntCode();
            intCode.LoadDataFromPath("data/day7_puzzle_input.txt");

            int result = 0;
            foreach (var phaseSetting in phaseCombinations)
            {                
                int output = RunAmplifiers(phaseSetting, intCode);
                if (output > result)
                    result = output;
            }
            return result;
        }

        private int RunAmplifiers(int[] inputs, IntCode original)
        {
            IntCodeSolver[] solvers = new IntCodeSolver[inputs.Length];
            for (int i = 0; i < solvers.Length; i++)
            {
                IntCodeSolver solver = new IntCodeSolver();
                solver.PresetInput = new Input();
                solver.PresetInput.AddValue(inputs[i]);
                solver.BreakOnOutput = true;
                solver.SetIntCode(original.CreateCopy());
                solvers[i] = solver;
            }

            int previousOutput = 0;
            while (!solvers[0].EndOfCode)
            {
                for (int i = 0; i < solvers.Length; i++)
                {
                    IntCodeSolver solver = solvers[i];
                    solver.PresetInput.AddValue(previousOutput);
                    solver.StepAll();
                    previousOutput = solver.Output;
                    solver.PresetInput.Reset();
                }
            }
            return previousOutput;
        }
    }
}