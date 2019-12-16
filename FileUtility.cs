using System.Reflection;

namespace AdventOfCode_2019
{
    public static class FileUtility
    {
        public static string GetApplicationPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}