using System.Collections.Generic;

namespace Day2.Instructions
{
    public class AdditionInstruction : IExecutable
    {
        private readonly List<int> _intcodeProgram;

        public int Addend1 { get; }
        public int Addend2 { get; }
        public int OutputAddress { get; }

        public int ParametersCount => 3;
        public bool Halt => false;

        public AdditionInstruction(int addend1, int addend2, int outputAddress, List<int> intcodeProgram)
        {
            Addend1 = addend1;
            Addend2 = addend2;
            OutputAddress = outputAddress;
            _intcodeProgram = intcodeProgram;
        }

        public void Execute() =>
            _intcodeProgram[OutputAddress] = Addend1 + Addend2;
    }
}
