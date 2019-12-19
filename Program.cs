using System;
using System.Text;
using AdventOfCode_2019.IntCodes;
using AdventOfCode_2019.Rendering;

namespace AdventOfCode_2019
{
    class Program
    {
        private static bool isRunning = true;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //IntCodeTests.RunBoostTests();
            RunPuzzleSolutions();
            ConsoleLoop();
        }

        private static void RunPuzzleSolutions()
        {
            IntCode code = new IntCode();
            code.LoadDataFromPath("data/day9_puzzle_input.txt");

            IntCodeSolver solver = new IntCodeSolver();
            solver.SetIntCode(code);
            solver.StepAll();

            Console.WriteLine($"Solution for Puzzle 1: {solver.Output}");
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
