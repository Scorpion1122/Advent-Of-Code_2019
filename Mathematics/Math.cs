namespace AdventOfCode_2019.Mathematics
{
    public static class Math
    {
        public static int Abs(int value)
        {
            return (value < 0) ? value * -1 : value;
        }

        public static int[] ToDigitArray(int value)
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