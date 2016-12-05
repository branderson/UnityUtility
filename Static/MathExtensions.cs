using System;

namespace Assets.Utility.Static
{
    public class MathExtensions
    {
        public static long Mod(long x, long m)
        {
            return (x%m + m)%m;
        }

        public static float Mod(float x, float m)
        {
            return x - m*(float)Math.Floor((double)x/m);
        }
    }
}