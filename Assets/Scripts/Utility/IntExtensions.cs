namespace Utility
{
    public static class ModuloExtension
    {
        /**
     * This is a modulo function which always returns a positive value.
     */
        public static int Mod(this int x, int m)
        {
            return (x % m + m) % m;
        }

        public static float Mod(this float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}