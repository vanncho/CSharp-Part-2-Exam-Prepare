namespace Even_Differences
{
    using System;
    using System.Collections.Generic;

    class EvenDifferences
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            long[] digits = new long[input.Length];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = long.Parse(input[i]);
            }

            long sum = 0;

            for (int i = 1; i < digits.Length; i++)
            {
                long absoluteDifferences = CalculateTheAbsoluteDiference(digits[i - 1], digits[i]);
                

                if (absoluteDifferences % 2 == 0)
                {
                    i++;
                    sum += absoluteDifferences;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(sum);
        }

        private static long CalculateTheAbsoluteDiference(long p1, long p2)
        {
            long absoluteDifferences = p1 - p2;

            if (absoluteDifferences < 0)
            {
                absoluteDifferences *= -1;
            }

            return absoluteDifferences;
        }
    }
}
