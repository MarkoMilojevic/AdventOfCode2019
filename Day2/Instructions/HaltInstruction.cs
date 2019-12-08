namespace Day2.Instructions
{
    public class HaltInstruction : IExecutable
    {
        public int ParametersCount => 3;
        public bool Halt => true;

        public void Execute()
        {
            // No-op.
        }
    }
}
