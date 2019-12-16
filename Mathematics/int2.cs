namespace AdventOfCode_2019.Mathematics
{
    public struct int2
    {
        public int x;
        public int y;

        public int SqrMagnitude => Math.Abs(x) + Math.Abs(y);

        public int2(int x, int y) : this()
        {
            this.x = x;
            this.y = y;
        }

        public static int2 operator +(int2 a, int2 b) => new int2(a.x + b.x, a.y + b.y);
        public static int2 operator *(int2 a, int b) => new int2(a.x * b, a.y * b);
        public static int2 operator *(int b, int2 a) => new int2(a.x * b, a.y * b);        
        public static bool operator ==(int2 a, int2 b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(int2 a, int2 b) => a.x != b.x || a.y != b.y;
    }
}