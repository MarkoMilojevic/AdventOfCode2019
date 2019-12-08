namespace Day2.Instructions
{
    public class HaltInstruction : IExecutable
    {
        public int ParametersCount => 0;
        public bool Halt => true;

        public void Execute()
        {
            // No-op.
        }
    }
}
