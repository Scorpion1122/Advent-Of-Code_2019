namespace AdventOfCode_2019
{
    public class PasswordSolver
    {
        public int CountPasswordPossibilities(int rangeFrom, int rangeTo, int maxSetLength)
        {
            int result = 0;
            for (int i = rangeFrom; i <= rangeTo; i++)
            {
                if (IsValidPassword(i, maxSetLength))
                    result ++;
            }
            return result;
        }

        public bool IsValidPassword(int value, int maxSetLength)
        {
            bool didDouble = false;
            int repeatCount = 1;

            int[] digits = ToDigitArray(value);
            int previous = digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                int digit = digits[i];
                if (digit == previous)
                {
                    repeatCount++;
                }
                else
                {
                    if (repeatCount != 1 && repeatCount <= maxSetLength)
                        didDouble = true;
                    repeatCount = 1;
                }

                if (digit < previous)
                    return false;

                previous = digit;
            }
            return didDouble || repeatCount != 1 && repeatCount <= maxSetLength;
        }

        private int[] ToDigitArray(int value)
        {
            int[] result = new int[(int)System.Math.Log10(value) + 1];
            for (int i = result.Length - 1; i >= 0; i--) 
            {
                result[i] = value % 10;
                value /= 10;
            }
            return result;
        }
    }
}