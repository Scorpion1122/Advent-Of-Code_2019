using AdventOfCode_2019.Mathematics;

namespace AdventOfCode_2019.IntCodes
{
    public class OpCode
    {
        public int InstructionCode { get; private set; }
        private ParamMode[] paramModes;

        public void ParseCode(int rawCode)
        {
            // 2 Most right digits are the Instruction Code
            // After that, from right to left are the param codes
            int[] digits = Mathematics.Math.ToDigitArray(rawCode);
            if (digits.Length == 1)
            {
                InstructionCode = digits[0];
                paramModes = null;
                return;
            }

            InstructionCode = digits[digits.Length - 1] + digits[digits.Length - 2] * 10;
            paramModes = new ParamMode[digits.Length - 2];
            for (int i = 0; i < digits.Length - 2; i++)
            {
                paramModes[i] = (ParamMode)digits[i];
            }
        }

        public ParamMode GetParamMode(int paramIndex)
        {
            if (paramModes == null)
                return ParamMode.Position;

            // Input value is from left to right, the array is from right to left
            // so invert the index
            int invertedIndex = paramModes.Length - paramIndex;
            return (invertedIndex < 0) ? ParamMode.Position : paramModes[invertedIndex];
        }
    }
}