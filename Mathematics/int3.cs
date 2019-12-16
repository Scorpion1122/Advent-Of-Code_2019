namespace AdventOfCode_2019.Mathematics
{
    public struct int3
    {
        public int x;
        public int y;
        public int z;

        public int SqrMagnitude => Math.Abs(x) + Math.Abs(y) + Math.Abs(z);

        public int3(int x, int y, int z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static int3 operator +(int3 a, int3 b) => new int3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static int3 operator *(int3 a, int b) => new int3(a.x * b, a.y * b, a.z * b);
        public static int3 operator *(int b, int3 a) => new int3(a.x * b, a.y * b, a.z * b);        
        public static bool operator ==(int3 a, int3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=(int3 a, int3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
    }
}