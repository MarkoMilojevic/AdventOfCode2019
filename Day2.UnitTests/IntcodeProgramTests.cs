using Day2.Factories;
using Day2.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Day2.UnitTests
{
    public class IntcodeProgramTests
    {
        private readonly ITestOutputHelper _output;

        public IntcodeProgramTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("1,0,0,0,99", 0, 2)]
        [InlineData("2,3,0,3,99", 3, 6)]
        [InlineData("2,4,4,5,99,0", 5, 9801)]
        [InlineData("1,1,1,4,99,5,6,0,99", 0, 30)]
        public void ProcessTests(string intcodeProgram, int position, int expectedValue)
        {
            IntcodeProgram program = new IntcodeProgram(
                intcodeProgram,
                new DefaultInstructionFactory(),
                new ImplicitOpcodeParser());

            List<int> output = program.Run();

            Assert.Equal(expectedValue, output[position]);
        }

        [Theory]
        [InlineData(12, 12, 2, 2, 6_327_510)]
        [InlineData(0, 99, 0, 99, 19_690_720)]
        public void Day2(int nounStart, int nounEnd, int verbStart, int verbEnd, int expectedOutput)
        {

            int[] intcodeProgram = File.ReadAllText("day2.txt")
                                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(number => int.Parse(number, CultureInfo.InvariantCulture))
                                .ToArray();

            for (int noun = nounStart; noun <= nounEnd; noun++)
            {
                for (int verb = verbStart; verb <= verbEnd; verb++)
                {
                    intcodeProgram[1] = noun;
                    intcodeProgram[2] = verb;

                    IntcodeProgram program = new IntcodeProgram(
                        intcodeProgram,
                        new DefaultInstructionFactory(),
                        new ImplicitOpcodeParser());

                    List<int> programOutput = program.Run();

                    if (programOutput[0] == expectedOutput)
                    {
                        _output.WriteLine($"noun: {noun}, verb: {verb}");
                        return;
                    }
                }
            }

            Assert.True(false, "Result not found.");
        }
    }
}
