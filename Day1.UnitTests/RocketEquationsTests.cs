using Xunit;
using static Day1.RocketEquations;

namespace Day1.UnitTests
{
    public class RocketEquationsTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void FuelRequiredTests(int mass, int expectedFuelRequired) =>
            Assert.Equal(expectedFuelRequired, FuelRequired(mass));
    }
}
