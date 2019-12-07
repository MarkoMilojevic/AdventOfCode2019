namespace Day3
{
    public class WireTrail
    {
        public int Row { get; }
        public int Column { get; }
        public int Ordinal { get; }

        public WireTrail(int row, int column, int ordinal)
        {
            Row = row;
            Column = column;
            Ordinal = ordinal;
        }
    }
}
