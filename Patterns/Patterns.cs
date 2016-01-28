namespace Patterns
{
    using System;

    class Patterns
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            int[,] digits = new int[n, n];

            for (int rows = 0; rows < n; rows++)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < currentLine.Length; cols++)
                {
                    digits[rows, cols] = int.Parse(currentLine[cols]);
                }
            }


            int sum = 0;
            string foundSum = "NO";

            for (int i = 0; i <= n - 5; i++)
            {
                for (int j = 0; j <= n - 3; j++)
                {
                    if (Pattern(digits, j, i))
                    {
                        int tempSum = SumOfDigitsByPattern(digits, j, i);

                        if (sum < tempSum)
                        {
                            sum = tempSum;
                            foundSum = "YES";
                        }
                    }
                }
            }

            if (sum == 0)
            {
                sum = FindDiagonalSumOfArray(digits);
            }

            if (foundSum == "NO")
            {
                Console.WriteLine("{0} {1}", foundSum, sum);
            }
            else
            {
                Console.WriteLine("{0} {1}", foundSum, sum);
            }
        }

        private static int FindDiagonalSumOfArray(int[,] digits)
        {
            int sum = 0;
            int row = 0;
            int col = 0;

            for (int i = 0; i < digits.GetLength(0); i++)
            {
                if (row < digits.GetLength(0) && col < digits.GetLength(1))
                {
                    sum += digits[row, col];
                    row++;
                    col++;
                }
            }

            return sum;
        }

        static int SumOfDigitsByPattern(int[,] digits, int row, int col)
        {
            int sum = digits[row, col] +
                      digits[row, col + 1] +
                      digits[row, col + 2] +
                      digits[row + 1, col + 2] +
                      digits[row + 2, col + 2] +
                      digits[row + 2, col + 3] +
                      digits[row + 2, col + 4];

            return sum;
        }

        static bool Pattern(int[,] digits, int row, int col)
        {
            if (digits[row, col] == digits[row, col + 1] - 1 &&
                digits[row, col + 1] == digits[row, col + 2] - 1 &&
                digits[row, col + 2] == digits[row + 1, col + 2] - 1 &&
                digits[row + 1, col + 2] == digits[row + 2, col + 2] - 1 &&
                digits[row + 2, col + 2] == digits[row + 2, col + 3] - 1 &&
                digits[row + 2, col + 3] == digits[row + 2, col + 4] - 1)  /// !!! (не проверявам последното!)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
