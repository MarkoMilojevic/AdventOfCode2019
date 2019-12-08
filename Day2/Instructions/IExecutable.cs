namespace Day2.Instructions
{
    public interface IExecutable
    {
        int ParametersCount { get; }
        bool Halt { get; }

        void Execute();

    }
}
