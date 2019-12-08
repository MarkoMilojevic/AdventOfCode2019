using Day2.Instructions;
using System;
using System.Collections.Generic;

namespace Day2.Parsers
{
    public class ImplicitOpcodeParser : IOpcodeParser
    {
        public int Opcode(int value) =>
            value;

        public IReadOnlyList<int> ParametersModes(int opcodeValue)
        {
            int opcode = Opcode(opcodeValue);

            return
                opcode == 99
                    ? new List<int>()
                : opcode == 1 || opcode == 2
                    ? new List<int> { 0, 0, 1 }
                : throw new ArgumentException("Unknown instruction opcode.", nameof(opcode));
        }
    }
}
