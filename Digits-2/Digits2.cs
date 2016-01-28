namespace Digits_2
{
    using System;
    using System.Collections.Generic;

    class Digits2
    {
        static int[,] digits;
        static List<bool[,]> InitializeOfPatternsInMatrix()
        {
            var list = new List<bool[,]>();

            // zero
            list.Add(new bool[,] 
            {
                //fake zero
            });

            // one
            list.Add(new bool[,] 
            {
                {false,false,true},
                {false,true,true},
                {true,false,true},
                {false,false,true},
                {false,false,true}
            });
            return list;
        }

        static bool CheckInPatterns(bool[,] patterns, int digit, int row, int col)
        {
            for (int i = 0; i < patterns.GetLength(0); i++)
            {
                for (int j = 0; j < patterns.GetLength(1); j++)
                {
                    if (patterns[i,j])
                    {
                        if (digits[row + i, col + j] != 1)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            digits = new int[n, n];

            var patterns = InitializeOfPatternsInMatrix();

            for (int i = 0; i < n; i++)
            {
                string[] currentCol = Console.ReadLine().Split(' ');
                for (int j = 0; j < currentCol.Length; j++)
                {
                    digits[i,j] = int.Parse(currentCol[j]);   
                }
            }

            int sum = 0;

            for (int row = 0; row <= n - 5; row++)
            {
                for (int col = 0; col <= n - 3; col++)
                {
                    if (digits[row + 2, col] == 1)
                    {
                        if (CheckInPatterns(patterns[1], 1, row, col))
                        {
                            sum += 1;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
