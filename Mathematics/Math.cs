namespace AdventOfCode_2019.Mathematics
{
    public static class Math
    {
        public static int Abs(int value)
        {
            return (value < 0) ? value * -1 : value;
        }

        public static long[] ToDigitArray(long value)
        {
            long[] result = new long[(long)System.Math.Log10(value) + 1];
            for (int i = result.Length - 1; i >= 0; i--) 
            {
                result[i] = value % 10;
                value /= 10;
            }
            return result;
        }
    }
}