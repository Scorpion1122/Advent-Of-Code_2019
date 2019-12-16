using System;

namespace AdventOfCode_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            CrossedWireSolver crossedWireSolver = new CrossedWireSolver();
            crossedWireSolver.ParseFileData("data/day3_puzzle1_input.txt");
            //crossedWireSolver.ParseFileData("data/day3_test1_input.txt");
            Console.WriteLine($"Solution To Puzzle 1: {crossedWireSolver.GetDistanceToClosestIntersection()}");
            Console.WriteLine($"Solution To Puzzle 2: {crossedWireSolver.GetDistanceToIntersectionWithShortestPath()}");
        }
    }
}
