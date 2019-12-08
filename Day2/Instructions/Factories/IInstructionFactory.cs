using Day2.Instructions;
using Day2.Parsers;
using System.Collections.Generic;

namespace Day2.Factories
{
    public interface IInstructionFactory
    {
        IExecutable Create(
            List<int> intcodeProgram,
            int instructionAddress,
            IOpcodeParser parametersModesParser);
    }
}
