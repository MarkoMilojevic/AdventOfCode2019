using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Day2.UnitTests
{
    public class IntcodeProgramTests
    {
        private readonly ITestOutputHelper output;

        public IntcodeProgramTests(ITestOutputHelper output) =>
            this.output = output;

        [Theory]
        [InlineData("1,0,0,0,99", 0, 2)]
        [InlineData("2,3,0,3,99", 3, 6)]
        [InlineData("2,4,4,5,99,0", 5, 9801)]
        [InlineData("1,1,1,4,99,5,6,0,99", 0, 30)]
        public void ProcessTests(string intcodeProgram, int position, int expectedValue)
        {
            int[] gravityAssistProgram = intcodeProgram.Process();

            Assert.Equal(expectedValue, gravityAssistProgram[position]);
        }

        [Theory]
        [InlineData(12, 12, 2, 2, 6_327_510)]
        [InlineData(0, 99, 0, 99, 19_690_720)]
        public void Day2(int nounStart, int nounEnd, int verbStart, int verbEnd, int expectedOutput)
        {
            string intcodeProgram = File.ReadAllText("day2.txt");

            int[] integers = intcodeProgram
                                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(number => int.Parse(number, CultureInfo.InvariantCulture))
                                .ToArray();

            for (int noun = nounStart; noun <= nounEnd; noun++)
            {
                for (int verb = verbStart; verb <= verbEnd; verb++)
                {
                    integers[1] = noun;
                    integers[2] = verb;
                    intcodeProgram = string.Join(',', integers);

                    int[] gravityAssistProgram = intcodeProgram.Process();
                    if (gravityAssistProgram[0] == expectedOutput)
                    {
                        output.WriteLine($"noun: {noun}, verb: {verb}");
                        return;
                    }
                }
            }

            Assert.True(false, "Result not found.");
        }
    }
}
