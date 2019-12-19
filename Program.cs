using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode_2019.Rendering;

namespace AdventOfCode_2019
{
    class Program
    {
        private static bool isRunning = true;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            RunPuzzleSolutions();
            ConsoleLoop();
        }

        private static void RunPuzzleSolutions()
        {
            Image image = new Image(25, 6);
            image.LoadDataFromFile("data/day8_puzzle_input.txt");
            int layer = image.GetLayerWithFewestOfNumber(0);
            int solution = image.GetNumberCountInLayer(layer, 1) * image.GetNumberCountInLayer(layer, 2);
            Console.WriteLine($"Solution to Puzzle 1: {solution}");

            image.RenderImage();
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
