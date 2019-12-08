using Day2.Instructions;
using System;
using System.Collections.Generic;

namespace Day2.Parsers
{
    public class ImplicitOpcodeParser : IOpcodeParser
    {
        public int Opcode(int value) =>
            value;

        public IReadOnlyList<ParameterMode> ParametersModes(int opcode)
        {
            int opcodeValue = Opcode(opcode);

            return
                opcodeValue == 99
                    ? new List<ParameterMode>()
                : opcodeValue == 1 || opcodeValue == 2
                    ? new List<ParameterMode>
                    {
                        ParameterMode.Position,
                        ParameterMode.Position,
                        ParameterMode.Immediate
                    }
                : throw new ArgumentException("Unknown instruction opcode.", nameof(opcodeValue));
        }
    }
}
