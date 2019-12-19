using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode_2019.Rendering
{
    public class Image
    {
        private int width;
        private int height;

        private List<int[]> layers = new List<int[]>();

        public Image(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void LoadDataFromFile(string path)
        {
            LoadDataFromString(File.ReadAllText(FileUtility.GetApplicationPath() + path));
        }

        public void LoadDataFromString(string data)
        {
            int index = 0;
            int[] layer = new int[width * height];
            
            foreach (char character in data)
            {
                if (!int.TryParse(character.ToString(), NumberStyles.Any, null, out int result))
                    throw new Exception($"Could not parse value {character}");
                
                layer[index] = result;
                index++;

                if (index >= layer.Length)
                {
                    layers.Add(layer);
                    layer = new int[width * height];
                    index = 0;
                }
            }
        }

        public void RenderImage()
        {
            for (int i = 0; i < (width * height); i++)
            {
                if (i % width == 0 && i != 0)
                    Console.Write("\n");
                RenderPixel(i);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void RenderPixel(int index)
        {
            int color = GetColor(index);
            ConsoleColor consoleColor = ConsoleColor.White;
            if (color == 0)
                consoleColor = ConsoleColor.DarkGray;

            string character = " ";
            if (color < 2)
                character = "█";

            Console.ForegroundColor = consoleColor;
            Console.Write(character);
        }

        // 0 = black
        // 1 = white
        // 2 = transparent
        private int GetColor(int index)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                int color = layers[i][index];
                if (color != 2)
                    return color;
            }
            return 2;
        }

        public int GetLayerWithFewestOfNumber(int number)
        {
            int lowestCount = int.MaxValue;
            int layer = -1;

            for (int i = 0; i < layers.Count; i++)
            {
                int count = GetNumberCountInLayer(i, number);
                if (count >= lowestCount)
                    continue;

                layer = i;
                lowestCount = count;
            }
            return layer;
        }

        public int GetNumberCountInLayer(int layer, int number)
        {
            return layers[layer].Where(x => x == number).Count();
        }
    }
}