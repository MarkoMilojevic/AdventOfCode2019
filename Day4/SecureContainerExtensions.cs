using System;
using System.Globalization;
using System.Linq;

namespace Day4
{
    public static class SecureContainerExtensions
    {
        public static int CountValidPasswords(int low, int high, Func<int, bool> adjacencyPredicate) =>
            Enumerable
                .Range(low, high - low + 1)
                .Where(password => password.IsValidPassword(adjacencyPredicate))
                .Count();

        public static bool IsValidPassword(this int password, Func<int, bool> adjacencyPredicate)
        {
            int[] digits = password.Digits();

            if (digits.Length != 6 || !digits.IsSorted())
                return false;

            int k = 0;
            while (k < digits.Length - 1)
            {
                int adjacentCount = 1;
                int j;
                for (j = k + 1; j < digits.Length; j++)
                {
                    if (digits[k] != digits[j])
                        break;

                    adjacentCount++;
                }

                if (adjacencyPredicate(adjacentCount))
                    return true;

                k = j;
            }

            return false;
        }

        private static int[] Digits(this int number) =>
            number
                .ToString(CultureInfo.InvariantCulture)
                .Select(c => int.Parse(c.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture))
                .ToArray();

        private static bool IsSorted(this int[] array)
        {
            for (int i = 1; i < array.Length; i++)
                if (array[i] < array[i - 1])
                    return false;

            return true;
        }
    }
}
