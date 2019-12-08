using Day2.Instructions;
using Day2.Parsers;
using System;
using System.Collections.Generic;

namespace Day2.Factories
{
    public class DefaultInstructionFactory : IInstructionFactory
    {
        public IExecutable Create(
            List<int> intcodeProgram,
            int instructionAddress,
            IOpcodeParser opcodeParser)
        {
            if (intcodeProgram is null)
                throw new ArgumentNullException(nameof(intcodeProgram));

            if (opcodeParser is null)
                throw new ArgumentNullException(nameof(opcodeParser));

            Opcode opcode = new Opcode(intcodeProgram[instructionAddress], opcodeParser);
            int[] parameters = opcode.Parameters(intcodeProgram, instructionAddress);

            switch (opcode.Value)
            {
                case 1:
                    return new AdditionInstruction(parameters[0], parameters[1], parameters[2], intcodeProgram);

                case 2:
                    return new MultiplicationInstruction(parameters[0], parameters[1], parameters[2], intcodeProgram);

                case 99:
                    return new HaltInstruction();

                default:
                    throw new ArgumentException("Unknown instruction opcode.", nameof(opcode.Value));
            }
        }
    }
}
