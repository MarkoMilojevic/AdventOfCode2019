using static System.Math;

namespace Day1
{
    public static class RocketEquations
    {
        public static int FuelRequired(int mass) =>
            (int)Floor((double)mass / 3) - 2;
    }
}
