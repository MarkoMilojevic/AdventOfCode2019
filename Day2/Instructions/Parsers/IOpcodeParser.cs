using Day2.Instructions;
using System.Collections.Generic;

namespace Day2.Parsers
{
    public interface IOpcodeParser
    {
        int Opcode(int value);
        IReadOnlyList<ParameterMode> ParametersModes(List<int> intcodeProgram, int instructionAddress);
    }
}
