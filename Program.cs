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
            GalaxyMap map = new GalaxyMap();
            map.LoadDataFromFile("data/day6_puzzle_input.txt");

            int totalOrbitCount = map.GetTotalOrbitCount();
            Console.WriteLine($"Solution for Puzzle 1: {totalOrbitCount}");
            
            int shortestDistance = map.GetShortestPath("YOU", "SAN");
            Console.WriteLine($"Solution for Puzzle 2: {shortestDistance}");
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
