using System;
using AdventOfCode_2019.Day1;

namespace AdventOfCode_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            SolvePuzzleOne();
            SolvePuzzleTwo();
        }

        private static void SolvePuzzleOne()
        {
            IntCode intCode = new IntCode();
            intCode.LoadDataFromPath("data/day2_puzzle_input.txt");
            intCode[1] = 12;
            intCode[2] = 2;

            IntCodeSolver solver = new IntCodeSolver();
            solver.SetIntCode(intCode);
            solver.StepAll();

            Console.WriteLine($"Solution Puzzle 1: {intCode[0]}");
        }

        private static void SolvePuzzleTwo()
        {
            IntCode intCode = new IntCode();
            intCode.LoadDataFromPath("data/day2_puzzle_input.txt");

            IntCodeSolver solver = new IntCodeSolver();
            for (int noun = 1; noun < 99; noun++)
            {
                for (int verb = 1; verb < 99; verb++)
                {
                    IntCode copy = intCode.CreateCopy();
                    copy[1] = noun;
                    copy[2] = verb;

                    solver.SetIntCode(copy);
                    solver.StepAll();

                    // 19690720 desired output
                    if (copy[0] == 19690720)
                    {
                        Console.WriteLine($"Solution Puzzle 2: {100 * noun + verb}");
                        return;
                    }
                }
            }
        }
    }
}
