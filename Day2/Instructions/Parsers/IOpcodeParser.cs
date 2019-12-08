using Day2.Instructions;
using System.Collections.Generic;

namespace Day2.Parsers
{
    public interface IOpcodeParser
    {
        int Opcode(int opcode);
        IReadOnlyList<int> ParametersModes(int opcode);
    }
}
