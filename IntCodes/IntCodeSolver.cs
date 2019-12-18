using System;

namespace AdventOfCode_2019.IntCodes
{
    public class IntCodeSolver
    {
        private IntCode intCode;
        private int stepIndex;
        private OpCode opCode = new OpCode();

        public bool EndOfCode { get; private set; }
        public bool VerboseOutput { get; set; }

        public void SetIntCode(IntCode intCode)
        {
            stepIndex = 0;
            this.intCode = intCode;
            EndOfCode = false;
        }

        public void StepAll()
        {
            while (!EndOfCode)
            {
                Step();
            }
        }

        public void Step()
        {
            if (EndOfCode)
                throw new System.Exception("Reached the end of the IntCode!");

            opCode.ParseCode(intCode[stepIndex]);
            switch (opCode.InstructionCode)
            {
                case 1:
                stepIndex = Add(stepIndex, opCode);
                break;

                case 2:
                stepIndex = Multiply(stepIndex, opCode);
                break;

                case 3:
                stepIndex = Input(stepIndex, opCode);
                break;

                case 4:
                stepIndex = Output(stepIndex, opCode);
                break;

                case 5:
                stepIndex = JumpIfTrue(stepIndex, opCode);
                break;

                case 6:
                stepIndex = JumpIfFalse(stepIndex, opCode);
                break;

                case 7:
                stepIndex = LessThan(stepIndex, opCode);
                break;

                case 8:
                stepIndex = Equals(stepIndex, opCode);
                break;

                case 99:
                EndOfCode = true;
                Console.WriteLine("Program Finished!\n");
                break;

                default:
                    throw new Exception($"Intruction Code {opCode.InstructionCode} not recognized!");
            }
        }

        private int Add(int stepIndex, OpCode opCode)
        {
            int valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            int valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            intCode.WriteValue(stepIndex + 3, valueOne + valueTwo, opCode.GetParamMode(3));

            return stepIndex += 4;
        }

        private int Multiply(int stepIndex, OpCode opCode)
        {
            int valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            int valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            intCode.WriteValue(stepIndex + 3, valueOne * valueTwo, opCode.GetParamMode(3));

            return stepIndex += 4;
        }

        private int Input(int stepIndex, OpCode opCode)
        {
            Console.WriteLine("Program requests input!");

            while (true)
            {
                string line = Console.ReadLine();
                if (int.TryParse(line, System.Globalization.NumberStyles.Any, null, out int intValue))
                {
                    intCode.WriteValue(stepIndex + 1, intValue, opCode.GetParamMode(1));
                    break;
                }
                Console.WriteLine("INVALID INPUT: Supply integer value");
            }            
            return stepIndex += 2;
        }

        private int Output(int stepIndex, OpCode opCode)
        {
            Console.WriteLine($"Output: {intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1))}");
            if (VerboseOutput)
            {
                Console.WriteLine($"- stepIndex {stepIndex}");
            }
            return stepIndex += 2;
        }

        private int JumpIfTrue(int stepIndex, OpCode opCode)
        {
            int boolValue = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));

            if (boolValue == 0) // false;
                return stepIndex += 3;
            return intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));
        }

        private int JumpIfFalse(int stepIndex, OpCode opCode)
        {
            int boolValue = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));

            if (boolValue == 0) // false
                return intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));
            return stepIndex += 3;
        }

        private int LessThan(int stepIndex, OpCode opCode)
        {
            int valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            int valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            int writeValue = (valueOne < valueTwo) ? 1 : 0;

            intCode.WriteValue(stepIndex + 3, writeValue, opCode.GetParamMode(3));
            return stepIndex += 4;
        }

        private int Equals(int stepIndex, OpCode opCode)
        {
            int valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            int valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            int writeValue = (valueOne == valueTwo) ? 1 : 0;

            intCode.WriteValue(stepIndex + 3, writeValue, opCode.GetParamMode(3));
            return stepIndex += 4;
        }
    }  
}