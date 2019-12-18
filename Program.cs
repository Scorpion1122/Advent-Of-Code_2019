using System;
using AdventOfCode_2019.IntCodes;

namespace AdventOfCode_2019
{
    class Program
    {
        private static bool isRunning = true;

        static void Main(string[] args)
        {
            RunPuzzleSolutions();
            ConsoleLoop();
        }

        private static void RunPuzzleSolutions()
        {
            IntCode intCode = new IntCode();
            intCode.LoadDataFromPath("data/day5_puzzle_input.txt");

            IntCodeSolver solver = new IntCodeSolver();

            Console.WriteLine("Solving Puzzle 1: (Input Required == 1)");
            solver.SetIntCode(intCode.CreateCopy());
            solver.StepAll();

            Console.WriteLine("Solving Puzzle 2: (Input Required == 5)");
            solver.SetIntCode(intCode.CreateCopy());
            solver.StepAll();
        }

        private static void ConsoleLoop()
        {
            while (isRunning)
            {
                string line = Console.ReadLine();

                if (line == "Q" || line == "q")
                    isRunning = false;
            }
        }
    }
}
