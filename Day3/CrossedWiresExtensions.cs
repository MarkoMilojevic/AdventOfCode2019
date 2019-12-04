using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day3
{
    public static class CrossedWiresExtensions
    {
        public static int MinManhattanDistance(string trail1, string trail2)
        {
            if (trail1 is null)
                throw new ArgumentNullException(nameof(trail1));

            if (trail2 is null)
                throw new ArgumentNullException(nameof(trail2));

            (bool firstWirePresent, bool secondWirePresent)[][] grid = CreateGrid(size: 40_000);

            grid.Track(trail1, (g, i, j) => g[i][j].firstWirePresent = true);
            grid.Track(trail2, (g, i, j) => g[i][j].secondWirePresent = true);

            return grid
                    .IntersectionsDistances()
                    .Min();
        }

        private static (bool firstWirePresent, bool secondWirePresent)[][] CreateGrid(int size)
        {
            (bool firstWirePresent, bool secondWirePresent)[][] grid = new (bool, bool)[size][];

            for (int i = 0; i < grid.Length; i++)
                grid[i] = new (bool, bool)[size];

            return grid;
        }

        private static void Track(
            this (bool firstWirePresent, bool secondWirePresent)[][] grid,
            string trail,
            Action<(bool firstWirePresent, bool secondWirePresent)[][], int, int> mark)
        {
            string[] wireTrails = trail.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int i = grid.Length / 2;
            int j = grid.Length / 2;
            foreach (string wireTrail in wireTrails)
            {
                string direction = wireTrail.Substring(0, 1);
                int trailLength = int.Parse(wireTrail.Substring(1, wireTrail.Length - 1), CultureInfo.InvariantCulture);                
                (int i, int j) weight = direction.Weight();

                for (int k = 0; k < trailLength; k++)
                {
                    i += weight.i;
                    j += weight.j;
                    mark(grid, i, j);
                }
            }
        }

        private static (int i, int j) Weight(this string direction)
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

        private static List<int> IntersectionsDistances(this (bool firstWirePresent, bool secondWirePresent)[][] grid)
        {
            List<int> intersections = new List<int>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j].firstWirePresent && grid[i][j].secondWirePresent)
                    {
                        intersections.Add(Math.Abs(i - grid.Length / 2) + Math.Abs(j - grid.Length / 2));
                    }
                }
            }

            return intersections;
        }
    }
}
