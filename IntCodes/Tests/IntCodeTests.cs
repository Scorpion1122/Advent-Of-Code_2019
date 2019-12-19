using System;

namespace AdventOfCode_2019.IntCodes
{
    public static class IntCodeTests
    {
        public static void RunAll()
        {            
            RunCompareTests();
            RunJumpTests();
            RunBoostTests();
        }

        // Big Numbers
        // Relative Mode
        // Increased Memory
        public static void RunBoostTests()
        {
            IntCode testCode = new IntCode();
            IntCodeSolver solver = new IntCodeSolver();

            Console.WriteLine("- Copy Self");
            testCode.LoadFromString("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99");
            solver.SetIntCode(testCode);
            solver.StepAll();
            
            Console.WriteLine("- Output 16 digit nr");
            testCode.LoadFromString("1102,34915192,34915192,7,4,7,99,0");
            solver.SetIntCode(testCode);
            solver.StepAll();
        }

        public static void RunCompareTests()
        {
            IntCode testCode = new IntCode();
            IntCodeSolver solver = new IntCodeSolver();
            
            Console.WriteLine("Running Compare Tests:");

            Console.WriteLine("- Equal to 8? \tPosition Mode");
            testCode.LoadFromString("3,9,8,9,10,9,4,9,99,-1,8");
            solver.SetIntCode(testCode);
            solver.StepAll();

            Console.WriteLine("- Less Then 8? \tPosition Mode");
            testCode.LoadFromString("3,9,7,9,10,9,4,9,99,-1,8");
            solver.SetIntCode(testCode);
            solver.StepAll();
            
            Console.WriteLine("- Equal to 8? \tImmediate Mode");
            testCode.LoadFromString("3,3,1108,-1,8,3,4,3,99");
            solver.SetIntCode(testCode);
            solver.StepAll();

            Console.WriteLine("- Less Then 8? \tImmediate Mode");
            testCode.LoadFromString("3,3,1107,-1,8,3,4,3,99");
            solver.SetIntCode(testCode);
            solver.StepAll();
        }

        public static void RunJumpTests()
        {
            IntCode testCode = new IntCode();
            IntCodeSolver solver = new IntCodeSolver();
            
            Console.WriteLine("Running Jump Tests:");

            Console.WriteLine("- Is Input <= 1 \tPosition Mode");
            testCode.LoadFromString("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9");
            solver.SetIntCode(testCode);
            solver.StepAll();
            
            Console.WriteLine("- Is Input >= 1 \tImmediate Mode");
            testCode.LoadFromString("3,3,1105,-1,9,1101,0,0,12,4,12,99,1");
            solver.SetIntCode(testCode);
            solver.StepAll();
        }
    } 
}