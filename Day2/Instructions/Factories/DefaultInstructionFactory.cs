using Day2.Instructions;
using System;
using System.Collections.Generic;

namespace Day2.Factories
{
    public class DefaultInstructionFactory : IInstructionFactory
    {
        public IExecutable Create(
            List<int> intcodeProgram,
            int opcode,
            params int[] parameters)
        {
            switch (opcode)
            {
                case 1:
                    return new AdditionInstruction(parameters[0], parameters[1], parameters[2], intcodeProgram);

                case 2:
                    return new MultiplicationInstruction(parameters[0], parameters[1], parameters[2], intcodeProgram);

                case 99:
                    return new HaltInstruction();

                default:
                    throw new ArgumentException("Unknown instruction opcode.", nameof(opcode));
            }
        }
    }
}
