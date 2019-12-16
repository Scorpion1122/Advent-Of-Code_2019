using System;
using AdventOfCode_2019.Day1;

namespace AdventOfCode_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            CorrectedFuelCounter fuelCounter = new CorrectedFuelCounter();
            fuelCounter.LoadInputData("data/day1_puzzle2_input.txt");
            Console.WriteLine(fuelCounter.CalculateFuelRequirement());
        }
    }
}
