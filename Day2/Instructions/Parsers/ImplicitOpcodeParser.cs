﻿using Day2.Instructions;
using System;
using System.Collections.Generic;

namespace Day2.Parsers
{
    public class ImplicitOpcodeParser : IOpcodeParser
    {
        public int Opcode(int value) =>
            value;

        public IReadOnlyList<ParameterMode> ParametersModes(List<int> intcodeProgram, int instructionAddress)
        {
            if (intcodeProgram is null)
                throw new ArgumentNullException(nameof(intcodeProgram));

            int opcode = Opcode(intcodeProgram[instructionAddress]);

            return
                opcode == 99
                    ? new List<ParameterMode>()
                : opcode == 1 || opcode == 2
                    ? new List<ParameterMode>
                    {
                        ParameterMode.Position,
                        ParameterMode.Position,
                        ParameterMode.Immediate
                    }
                : throw new ArgumentException("Unknown instruction opcode.", nameof(opcode));
        }
    }
}