using Day2.Factories;
using Day2.Instructions;
using Day2.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day2
{
    public class IntcodeProgram
    {
        private List<int> _program { get; }
        private readonly IInstructionFactory _instructionFactory;
        private readonly IOpcodeParser _opcodeParser;

        public IntcodeProgram(string value, IInstructionFactory instructionFactory, IOpcodeParser opcodeParser)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            _program = value
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(number => int.Parse(number, CultureInfo.InvariantCulture))
                        .ToList();

            _instructionFactory = instructionFactory ?? throw new ArgumentNullException(nameof(instructionFactory));
            _opcodeParser = opcodeParser ?? throw new ArgumentNullException(nameof(opcodeParser));
        }

        public IntcodeProgram(int[] value, IInstructionFactory instructionFactory, IOpcodeParser opcodeParser)
        {
            _program = value?.ToList() ?? throw new ArgumentNullException(nameof(value));
            _instructionFactory = instructionFactory ?? throw new ArgumentNullException(nameof(instructionFactory));
            _opcodeParser = opcodeParser ?? throw new ArgumentNullException(nameof(opcodeParser));
        }
        
        public List<int> Run()
        {
            List<int> output = _program.ToList();

            int currentInstructionAddress = 0;
            IExecutable instruction;
            do
            {
                instruction = _instructionFactory.Create(
                    output,
                    currentInstructionAddress,
                    _opcodeParser);

                instruction.Execute();

                currentInstructionAddress += instruction.ParametersCount + 1;
            }
            while (!instruction.Halt);

            return output;
        }
    }
}
