using Xunit;
using static Day4.SecureContainerExtensions;

namespace Day4.UnitTests
{
    public class SecureContainerTests
    {
        [Theory]
        [InlineData(111111, true)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        public void CountPasswordTests(int password, bool isValid) =>
            Assert.Equal(isValid, password.IsValidPassword(adjacentCount => adjacentCount >= 2));

        [Theory]
        [InlineData(112233, true)]
        [InlineData(123444, false)]
        [InlineData(111122, true)]
        public void CountPassword2Tests(int password, bool isValid) =>
            Assert.Equal(isValid, password.IsValidPassword(adjacentCount => adjacentCount == 2));

        [Fact]
        public void Day4()
        {
            const int ExpectedValidPasswords = 1154;
            const int ExpectedValidPasswords2 = 750;

            Assert.Equal(ExpectedValidPasswords, CountValidPasswords(240920, 789857, adjacentCount => adjacentCount >= 2));
            Assert.Equal(ExpectedValidPasswords2, CountValidPasswords(240920, 789857, adjacentCount => adjacentCount == 2));
        }
    }
}
