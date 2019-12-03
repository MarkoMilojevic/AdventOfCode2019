using System;
using System.Globalization;
using System.Linq;
using static Day2.Properties.Resources;

namespace Day2
{
    public static class IntcodePrograms
    {
        public static int[] Process(this string intcodeProgram)
        {
            if (intcodeProgram is null)
                return Array.Empty<int>();

            int[] integers = intcodeProgram
                                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(number => int.Parse(number, CultureInfo.InvariantCulture))
                                .ToArray();

            return integers.ProcessInternal(inPlaceModification: true);
        }

        public static int[] Process(this int[] intcodeProgram)
        {
            if (intcodeProgram is null)
                return Array.Empty<int>();

            return intcodeProgram.ProcessInternal(inPlaceModification: false);
        }

        private static int[] ProcessInternal(this int[] intcodeProgram, bool inPlaceModification)
        {
            int[] integers = inPlaceModification
                                ? intcodeProgram
                                : intcodeProgram.ToArray();

            int i = 0;
            while (i < integers.Length - 3 && integers[i] != 99)
            {
                int firstOperandIndex = integers[i + 1];
                int secondOperandIndex = integers[i + 2];
                int resultIndex = integers[i + 3];

                if (integers[i] == 1)
                    integers[resultIndex] = integers[firstOperandIndex] + integers[secondOperandIndex];
                else if (integers[i] == 2)
                    integers[resultIndex] = integers[firstOperandIndex] * integers[secondOperandIndex];

                i += 4;
            }

            return integers[i] == 99
                ? integers
                : throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        ResourceManager.GetString("InvalidIntcodeProgram", CultureInfo.InvariantCulture),
                        nameof(intcodeProgram)));
        }
    }
}
