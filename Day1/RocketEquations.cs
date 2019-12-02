using static System.Math;

namespace Day1
{
    public static class RocketEquations
    {
        public static int FuelRequired(int mass) =>
            (int)Floor((double)mass / 3) - 2;

        public static int FuelRequired2(int mass)
        {
            int totalFuelRequired = 0;

            int remainingMass = mass;
            int fuelRequiredForRemainingMass = 0;
            while (fuelRequiredForRemainingMass >= 0)
            {
                fuelRequiredForRemainingMass = (int)Floor((double)remainingMass / 3) - 2;
                remainingMass = fuelRequiredForRemainingMass;

                if (remainingMass < 0)
                {
                    break;
                }

                totalFuelRequired += fuelRequiredForRemainingMass;
            }

            return totalFuelRequired;
        }
    }
}
