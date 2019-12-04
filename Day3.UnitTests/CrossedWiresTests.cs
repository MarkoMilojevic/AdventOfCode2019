using Xunit;
using static FileExtensions.FileExtensions;

namespace Day3.UnitTests
{
    public class CrossedWiresTests
    {
        [Theory]
        [InlineData(
            "R8,U5,L5,D3",
            "U7,R6,D4,L4",
            6)]
        [InlineData(
            "R75,D30,R83,U83,L12,D49,R71,U7,L72",
            "U62,R66,U55,R34,D71,R55,D58,R83",
            159)]
        [InlineData(
            "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
            "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7",
            135)]
        public void MinManhattanDistanceTests(string trail1, string trail2, int expectedMin) =>
            Assert.Equal(expectedMin, CrossedWiresExtensions.MinManhattanDistance(trail1, trail2));

        [Fact]
        public void Day3()
        {
            const int ExpectedMin = 1017;

            string[] trails = ReadStringArrayFromFile("day3.txt");
            string trail1 = trails[0];
            string trail2 = trails[1];

            Assert.Equal(ExpectedMin, CrossedWiresExtensions.MinManhattanDistance(trail1, trail2));
        }
    }
}
