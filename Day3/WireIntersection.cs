namespace Day3
{
    public class WireIntersection
    {
        public int Row { get; }
        public int Column { get; }
        public int FirstWireTrailOrdinal { get; }
        public int SecondWireTrailOrdinal { get; }

        public WireIntersection(int row, int column, int firstWireTrailOrdinal, int secondWireTrailOrdinal)
        {
            Row = row;
            Column = column;
            FirstWireTrailOrdinal = firstWireTrailOrdinal;
            SecondWireTrailOrdinal = secondWireTrailOrdinal;
        }
    }
}
