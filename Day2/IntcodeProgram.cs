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
                    _opcodeParser.Opcode(output[currentInstructionAddress]),
                    Parameters(output, currentInstructionAddress));

                instruction.Execute();

                currentInstructionAddress += instruction.ParametersCount + 1;
            }
            while (!instruction.Halt);

            return output;
        }

        /// <remarks>
        /// If we were to introduce new parameter modes,
        /// this would need to be abstracted away.
        /// </remarks>
        private int[] Parameters(List<int> intcodeProgram, int instructionAddress)
        {
            int opcodeValue = intcodeProgram[instructionAddress];
            IReadOnlyList<int> parametersModes = _opcodeParser.ParametersModes(opcodeValue);

            return Enumerable
                .Range(instructionAddress + 1, parametersModes.Count)
                .Zip(
                    parametersModes,
                    (paramAddress, mode) => mode == 1
                                                ? intcodeProgram[paramAddress]
                                            : mode == 0
                                                ? intcodeProgram[intcodeProgram[paramAddress]]
                                            : throw new ArgumentOutOfRangeException(nameof(mode)))
                .ToArray();
        }
    }
}
