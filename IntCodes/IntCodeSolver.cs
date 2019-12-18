namespace AdventOfCode_2019.IntCodes
{
    public class IntCodeSolver
    {
        private IntCode intCode;
        private OpCode opCode = new OpCode();

        private int stepIndex;
        public bool EndOfCode { get; private set; }

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

            //int opCode = intCode[stepIndex];
            opCode.ParseCode(intCode[stepIndex]);
            switch (opCode.InstructionCode)
            {
                case 1: // Add
                stepIndex = Add(stepIndex, opCode);
                break;

                case 2: // Multiply
                stepIndex = Multiply(stepIndex, opCode);
                break;

                case 99:
                EndOfCode = true;
                break;
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
    }  
}