using System;

namespace AdventOfCode_2019.IntCodes
{
    public class IntCodeSolver
    {
        private IntCode intCode;
        private int stepIndex;
        private OpCode opCode = new OpCode();

        public Input PresetInput { get; set; }

        public long Output { get; private set; }
        public bool OutputSet { get; private set; }
        public bool BreakOnOutput { get; set; }

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
            OutputSet = false;
            while (!EndOfCode && (!BreakOnOutput || !OutputSet))
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
                stepIndex = ReadInput(stepIndex, opCode);
                break;

                case 4:
                stepIndex = WriteOutput(stepIndex, opCode);
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

                case 9:
                stepIndex = UpdateRelativeBase(stepIndex, opCode);
                break;

                case 99:
                End(stepIndex);                
                break;

                default:
                    throw new Exception($"Intruction Code {opCode.InstructionCode} not recognized!");
            }
        }

        private int Add(int stepIndex, OpCode opCode)
        {
            long valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            long valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            intCode.WriteValue(stepIndex + 3, valueOne + valueTwo, opCode.GetParamMode(3));

            return stepIndex += 4;
        }

        private int Multiply(int stepIndex, OpCode opCode)
        {
            long valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            long valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            intCode.WriteValue(stepIndex + 3, valueOne * valueTwo, opCode.GetParamMode(3));

            return stepIndex += 4;
        }

        private int ReadInput(int stepIndex, OpCode opCode)
        {
            int inputValue = 0;

            if (PresetInput != null && PresetInput.HasNextValue())
            {
                inputValue = PresetInput.GetNextValue();
            }
            else
            {
                Console.WriteLine("Program requests input!");
                while (true)
                {
                    string line = Console.ReadLine();
                    if (int.TryParse(line, System.Globalization.NumberStyles.Any, null, out int intValue))
                    {
                        inputValue = intValue;
                        break;
                    }
                    Console.WriteLine("INVALID INPUT: Supply integer value");
                }  
            }

            if (VerboseOutput)
            {
                Console.WriteLine($"- input {inputValue}");
            }

            intCode.WriteValue(stepIndex + 1, inputValue, opCode.GetParamMode(1));                      
            return stepIndex += 2;
        }

        private int WriteOutput(int stepIndex, OpCode opCode)
        {
            Output = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            Console.WriteLine($"Output: {Output}");
            if (VerboseOutput)
            {
                Console.WriteLine($"- stepIndex {stepIndex}");
            }
            OutputSet = true;
            return stepIndex += 2;
        }

        private int JumpIfTrue(int stepIndex, OpCode opCode)
        {
            long boolValue = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));

            if (boolValue == 0) // false;
                return stepIndex += 3;
            return (int)intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));
        }

        private int JumpIfFalse(int stepIndex, OpCode opCode)
        {
            long boolValue = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));

            if (boolValue == 0) // false
                return (int)intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));
            return stepIndex += 3;
        }

        private int LessThan(int stepIndex, OpCode opCode)
        {
            long valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            long valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            long writeValue = (valueOne < valueTwo) ? 1 : 0;

            intCode.WriteValue(stepIndex + 3, writeValue, opCode.GetParamMode(3));
            return stepIndex += 4;
        }

        private int Equals(int stepIndex, OpCode opCode)
        {
            long valueOne = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            long valueTwo = intCode.GetValue(stepIndex + 2, opCode.GetParamMode(2));

            long writeValue = (valueOne == valueTwo) ? 1 : 0;

            intCode.WriteValue(stepIndex + 3, writeValue, opCode.GetParamMode(3));
            return stepIndex += 4;
        }

        private int UpdateRelativeBase(int stepIndex, OpCode opCode)
        {
            long offset = intCode.GetValue(stepIndex + 1, opCode.GetParamMode(1));
            intCode.RelativeBase += offset;
            return stepIndex += 2;
        }

        private void End(int stepIndex)
        {
            EndOfCode = true;
            if (VerboseOutput)
            {                
                Console.WriteLine("Program Finished!");
                Console.WriteLine($"- stepIndex {stepIndex}\n");
            }
            else
            {                
                Console.WriteLine("Program Finished!\n");
            }
        }
    }  
}