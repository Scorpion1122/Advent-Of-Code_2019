namespace AdventOfCode_2019
{
    public class IntCodeSolver
    {
        private IntCode intCode;
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

            int opCode = intCode[stepIndex];
            switch (opCode)
            {
                case 1: // Add
                Add(stepIndex);
                break;

                case 2: // Multiply
                Multiply(stepIndex);
                break;

                case 99:
                EndOfCode = true;
                break;
            }
            stepIndex += 4;
        }

        private void Add(int opCodeIndex)
        {
            int valueOne = intCode.GetPointerValue(opCodeIndex + 1);
            int valueTwo = intCode.GetPointerValue(opCodeIndex + 2);

            intCode.WritePointerValue(opCodeIndex + 3, valueOne + valueTwo);
        }

        private void Multiply(int opCodeIndex)
        {
            int valueOne = intCode.GetPointerValue(opCodeIndex + 1);
            int valueTwo = intCode.GetPointerValue(opCodeIndex + 2);

            intCode.WritePointerValue(opCodeIndex + 3, valueOne * valueTwo);
        }
    }  
}