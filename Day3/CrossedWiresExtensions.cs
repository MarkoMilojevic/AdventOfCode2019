using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Math;

namespace Day3
{
    public static class CrossedWiresExtensions
    {
        public static int MinManhattanDistance(this List<WireIntersection> intersections) =>
            intersections
                .Select(wireIntersection => Abs(wireIntersection.Row) + Abs(wireIntersection.Column))
                .Min();

        public static int MinSignalDelay(this List<WireIntersection> intersections) =>
            intersections
                .Select(intersection => intersection.FirstWireTrailOrdinal + intersection.SecondWireTrailOrdinal)
                .Min();

        public static List<WireIntersection> Intersections(string trail1, string trail2)
        {
            if (trail1 is null)
                throw new ArgumentNullException(nameof(trail1));

            if (trail2 is null)
                throw new ArgumentNullException(nameof(trail2));

            List<WireTrail> firstWireTrails = trail1.Track();
            List<WireTrail> secondWireTrails = trail2.Track();

            List<WireIntersection> intersections = new List<WireIntersection>();

            HashSet<(int row, int column)> intersectionCells = new HashSet<(int row, int column)>();
            Dictionary<(int row, int column), WireTrail> wireTrailsByPosition = new Dictionary<(int, int), WireTrail>();
            foreach (WireTrail firstWireTrail in firstWireTrails)
            {
                intersectionCells.Add((firstWireTrail.Row, firstWireTrail.Column));
                if (!wireTrailsByPosition.ContainsKey((firstWireTrail.Row, firstWireTrail.Column)))
                {
                    wireTrailsByPosition.Add((firstWireTrail.Row, firstWireTrail.Column), firstWireTrail);
                }
            }

            foreach (WireTrail secondWireTrail in secondWireTrails)
            {
                if (intersectionCells.Contains((secondWireTrail.Row, secondWireTrail.Column)))
                {
                    intersections.Add(new WireIntersection(
                        secondWireTrail.Row,
                        secondWireTrail.Column,
                        wireTrailsByPosition[(secondWireTrail.Row, secondWireTrail.Column)].Ordinal,
                        secondWireTrail.Ordinal));
                }
            }

            return intersections;
        }

        private static List<WireTrail> Track(this string trail)
        {
            List<WireTrail> wireTrails = new List<WireTrail>();

            string[] tracks = trail.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int row = 0;
            int column = 0;
            int ordinal = 0;
            foreach (string track in tracks)
            {
                string direction = track.Substring(0, 1);
                int trailLength = int.Parse(track.Substring(1, track.Length - 1), CultureInfo.InvariantCulture);
                (int rowIncrement, int columnIncrement) = direction.DirectionIncrements();

                for (int i = 0; i < trailLength; i++)
                {
                    row += rowIncrement;
                    column += columnIncrement;
                    ordinal++;

                    wireTrails.Add(new WireTrail(row, column, ordinal));
                }
            }

            return wireTrails;
        }

        private static (int i, int j) DirectionIncrements(this string direction)
        {
            switch (direction)
            {
                case "R":
                    return (0, 1);

                case "L":
                    return (0, -1);

                case "U":
                    return (1, 0);

                case "D":
                    return (-1, 0);
            }

            throw new ArgumentException("Unknown direction", nameof(direction));
        }
    }
}
