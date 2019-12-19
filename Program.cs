using System;
using System.Collections.Generic;
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
            Amplifier amplifier = new Amplifier();
            amplifier.SetPhaseSettings(new int[] {0, 1, 2, 3, 4});
            Console.WriteLine($"Solution To Puzzle 1: {amplifier.GetHighestOutputValue()}");

            FeedbackAmplifier feedbackAmplifier = new FeedbackAmplifier();
            feedbackAmplifier.SetPhaseSettings(new int[] {5, 6, 7, 8, 9});
            Console.WriteLine($"Solution To Puzzle 2: {feedbackAmplifier.GetHighestOutputValue()}");

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
