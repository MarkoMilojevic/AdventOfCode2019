using System.Linq;
using Xunit;
using static Day1.RocketEquations;
using static FileExtensions.FileExtensions;

namespace Day1.UnitTests
{
    public class RocketEquationsTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void FuelRequired1Tests(int mass, int expectedFuelRequired) =>
            Assert.Equal(expectedFuelRequired, FuelRequired(mass));

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void FuelRequired2Tests(int mass, int expectedFuelRequired) =>
            Assert.Equal(expectedFuelRequired, FuelRequired2(mass));

        [Theory]
        [InlineData(1, 3_160_932)]
        [InlineData(2, 4_738_549)]
        public void Day1(int puzzlePart, int expectedAnswer)
        {
            int answer = ReadIntArrayFromFile($"day1_{puzzlePart}.txt")
                            .Select(mass => puzzlePart == 1 
                                                ? FuelRequired(mass)
                                                : FuelRequired2(mass))
                            .Sum();

            Assert.Equal(expectedAnswer, expectedAnswer);
        }
    }
}
