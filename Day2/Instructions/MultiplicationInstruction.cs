using System.Collections.Generic;

namespace Day2.Instructions
{
    public class MultiplicationInstruction : IExecutable
    {
        private readonly List<int> _intcodeProgram;

        public int Factor1 { get; }
        public int Factor2 { get; }
        public int OutputAddress { get; }

        public int ParametersCount => 3;
        public bool Halt => false;

        public MultiplicationInstruction(int factor1, int factor2, int outputAddress, List<int> intcodeProgram)
        {
            Factor1 = factor1;
            Factor2 = factor2;
            OutputAddress = outputAddress;
            _intcodeProgram = intcodeProgram;
        }

        public void Execute() =>
            _intcodeProgram[OutputAddress] = Factor1 * Factor2;
    }
}
