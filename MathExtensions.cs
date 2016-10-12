namespace Assets.Scripts.Utility
{
    public class MathExtensions
    {
        public static long Mod(long x, long m)
        {
            return (x%m + m)%m;
        }
    }
}