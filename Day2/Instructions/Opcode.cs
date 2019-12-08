using Day2.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Instructions
{
    public class Opcode
    {
        private readonly IOpcodeParser _opcodeParser;

        public int Value { get; }

        public Opcode(int value, IOpcodeParser opcodeParser)
        {
            if (opcodeParser is null)
                throw new ArgumentNullException(nameof(opcodeParser));
            
            _opcodeParser = opcodeParser;
            Value = _opcodeParser.Opcode(value);
        }

        public int[] Parameters(List<int> intcodeProgram, int instructionAddress)
        {
            IReadOnlyList<ParameterMode> parametersModes = _opcodeParser.ParametersModes(intcodeProgram, instructionAddress);

            return Enumerable
                .Range(instructionAddress + 1, parametersModes.Count)
                .Zip(
                    parametersModes,
                    (paramAddress, mode) => mode == ParameterMode.Immediate
                                                ? intcodeProgram[paramAddress]
                                            : mode == ParameterMode.Position
                                                ? intcodeProgram[intcodeProgram[paramAddress]]
                                            : throw new ArgumentOutOfRangeException(nameof(mode)))
                .ToArray();
        }
    }
}
