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

        [Fact]
        public void Day1()
        {
            const int ExpectedFuelRequired = 3_160_932;
            const int ExpectedFuelRequired2 = 4_738_549;

            int[] masses = ReadIntArrayFromFile("day1.txt");

            Assert.Equal(ExpectedFuelRequired, masses.Select(mass => FuelRequired(mass)).Sum());
            Assert.Equal(ExpectedFuelRequired2, masses.Select(mass => FuelRequired2(mass)).Sum());
        }
    }
}
