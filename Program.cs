using System;

namespace AdventOfCode_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordSolver solver = new PasswordSolver();
            Console.WriteLine(solver.IsValidPassword(111122, 2));
            Console.WriteLine($"Solution To Puzzle 1: {solver.CountPasswordPossibilities(158126, 624574, int.MaxValue)}");
            Console.WriteLine($"Solution To Puzzle 2: {solver.CountPasswordPossibilities(158126, 624574, 2)}");
        }
    }
}
